using FTT.DataAccesss;
using FTT.DbEntity;
using FTT.GraphScreen;
using FTT.Services;
using FTT.Services.Track;
using FTT.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using System.Data;

namespace FTT.UserControls
{
    public partial class TrackUC : UserControl
    {
        private readonly IRepository<Exercise> _exerciseRepository;
        private readonly IRepository<Setting> _settingRepository;
        private readonly IRepository<ToolTimer> _toolTimerRepository;
        private readonly IRepository<ProgressiveOverload> _progressiveOverloadRepository;
        private readonly ITrackService _trackService;
        private readonly IWorkoutService _workoutService;
        private readonly MainForm _mainForm;

        private bool _isWorkingExerciseInSession;
        private int _exerciseId;
        private int _exerciseMultiplier;
        private BindingList<TrackListViewModel> _trackList = [];
        private int _workingExerciseId = 0;
        private decimal _previousTotalVolume = 0;
        private decimal _currentWeightUsed = 0;
        private int _lastStrikeCount = 0;
        private List<GraphViewModel> _dataPoints;
        private Setting exerciseSettings = null!;

        public event EventHandler TriggerButtonEvent;

        public TrackUC(MainForm mainForm)
        {
            InitializeComponent();

            _exerciseRepository = Session.Instance.ServiceProvider.GetRequiredService<IRepository<Exercise>>();
            _trackService = Session.Instance.ServiceProvider.GetRequiredService<ITrackService>();
            _workoutService = Session.Instance.ServiceProvider.GetRequiredService<IWorkoutService>();
            _settingRepository = Session.Instance.ServiceProvider.GetRequiredService<IRepository<Setting>>();
            _toolTimerRepository = Session.Instance.ServiceProvider.GetRequiredService<IRepository<ToolTimer>>();
            _progressiveOverloadRepository = Session.Instance.ServiceProvider.GetRequiredService<IRepository<ProgressiveOverload>>();

            _isWorkingExerciseInSession = false;
            _mainForm = mainForm;

            FinishButton.Enabled = false;
            dtWorkingDate.MaxDate = DateTime.Today.AddDays(1).AddSeconds(-1);
            AddToTrackButton.Enabled = false;
            RepeatLastButton.Enabled = false;
            RemoveFromTrackButton.Enabled = false;

            SetButtonTooltip();

            lstTrack.DataSource = _trackList;
            lstTrack.DisplayMember = "Display";

            LoadExercises();

            cbExercises.SelectedValue = 0;
        }

        private void LoadExercises()
        {
            var exercises = _exerciseRepository.GetAll()
                .OrderByDescending(x => x.Category)
                .Select(x => new ComboBoxViewModel(x.Id, $"{x.Category} - {x.Name}"))
                .ToList();

            exercises.Add(new(null, ""));

            cbExercises.DataSource = exercises;

            cbExercises.ValueMember = "ValueMember";
            cbExercises.DisplayMember = "DisplayMember";
        }

        private void cbExercises_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_isWorkingExerciseInSession)
            {
                ComboBoxViewModel selectedExercise = cbExercises.SelectedItem as ComboBoxViewModel;

                if (selectedExercise != null && selectedExercise.ValueMember != null)
                {
                    _exerciseId = (int)selectedExercise.ValueMember;
                    _exerciseMultiplier = _exerciseRepository.GetById(_exerciseId)?.Multiplier ?? 1;

                    exerciseSettings = LoadExerciseSettings(_exerciseId);

                    StartButton.Visible = true;
                    FinishButton.Visible = true;

                    if (_trackService.LastExerciseTrackingExists((int)selectedExercise.ValueMember))
                    {
                        LoadLastWorkingExerciseNotes();
                        LoadLastTracking();
                    }
                    else
                    {
                        groupNotes.Visible = false;
                        groupLastTracking.Visible = false;
                    }
                }
                else
                {
                    StartButton.Visible = false;
                    FinishButton.Visible = false;
                    groupNotes.Visible = false;
                    groupLastTracking.Visible = false;
                    MainPanel.Visible = false;
                }
            }
        }

        private Setting LoadExerciseSettings(int exerciseId)
        {
            return _settingRepository
                .Find(x => x.ExerciseId == exerciseId)
                .FirstOrDefault();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            _isWorkingExerciseInSession = true;

            StartButton.Enabled = false;
            FinishButton.Enabled = true;
            cbExercises.Enabled = false;

            SetupWorkoutButtons();
            var newWorkingExerciseId = CreateInitialWorkingExercise();

            if (newWorkingExerciseId > 0)
            {
                AddWorkingExerciseToWorkout(newWorkingExerciseId);
            }

            SetRepRangeIntervalLabel();
            SetUpdateWorkoutDateButton();
            LoadWorkingExerciseHistory();

            MainPanel.Visible = true;

            SetMainFormButtonEnabled(false);
        }

        private void SetRepRangeIntervalLabel()
        {
            if (exerciseSettings != null)
            {
                var minReps = exerciseSettings.MinReps;
                var maxReps = exerciseSettings.MaxReps;

                lblIntervalInUse.Text = $"{minReps} - {maxReps}";
            }
        }

        private void SetUpdateWorkoutDateButton()
        {
            var activeWorkoutId = Session.Instance.ActiveWorkoutId;

            if (activeWorkoutId != null && activeWorkoutId > 0)
            {
                UpdateWorkoutDateButton.Enabled = dtWorkingDate.Value.Date != DateTime.Today.Date;
            }
            else
            {
                UpdateWorkoutDateButton.Enabled = false;
            }
        }

        private void FinishButton_Click(object sender, EventArgs e)
        {
            var trackListItems = lstTrack.Items.Count;

            if (trackListItems > 0)
            {
                var exerciseSettings = this.exerciseSettings;
                var minSets = exerciseSettings?.MinSets;

                if (trackListItems < minSets)
                {
                    var messageResponse = MessageBox.Show($"There is minimum of {minSets} set(s) needed to finish. Are you sure?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (messageResponse == DialogResult.No)
                    {
                        return;
                    }
                }

                _trackService.AddSetsToWorkingExercise(_trackList.ToList(), _workingExerciseId);

                FinishWorkingExerciseSession();
            }
            else
            {
                var messageResponse = MessageBox.Show("Are you sure you want to finish without any sets added to the list?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (messageResponse == DialogResult.No)
                {
                    return;
                }
            }

            _isWorkingExerciseInSession = false;

            FinishButton.Enabled = false;
            cbExercises.Enabled = true;
            StartButton.Enabled = true;
            groupNotes.Visible = false;
            groupLastTracking.Visible = false;
            MainPanel.Visible = false;
            cbExercises.SelectedValue = 0;
            RepeatLastButton.Enabled = false;
            RemoveFromTrackButton.Enabled = false;
            SetupExerciseSetLables(6, false);

            SetMainFormButtonEnabled(true);
        }

        private void FinishWorkingExerciseSession()
        {
            var rulesResult = RulesOfProgression();

            var workingExercise = new WorkingExercise
            {
                Id = _workingExerciseId,
                ExerciseId = _exerciseId,
                FailCount = rulesResult.FailCount,
                Notes = rulesResult.Notes,
                WorkingDate = dtWorkingDate.Value
            };

            _trackService.FinishWorkingExercise(workingExercise);

            ResetControls();
        }

        private RulesResultViewModel RulesOfProgression()
        {
            var currentTotalVolume = _trackList.Sum(x => x.Reps * x.Weight * _exerciseMultiplier);
            var currentTotalSets = _trackList.Count;
            var exerciseSettings = this.exerciseSettings;
            var currentWeightUsed = _trackList.Min().Weight;
            var totalReps = _trackList.Sum(x => x.Reps);

            var maxFailAttempts = exerciseSettings?.FailAttempts;
            var maxReps = exerciseSettings?.MaxReps;
            var minReps = exerciseSettings?.MinReps;
            var minSets = exerciseSettings?.MinSets;
            var notes = string.Empty;
            var failAttempts = 0;

            var anySetsUnderMaxReps = _trackList.Any(x => x.Reps < maxReps);
            var anySetsUnderMinReps = _trackList.Any(x => x.Reps < minReps);

            if (anySetsUnderMinReps || currentTotalSets < minSets)
            {
                failAttempts++;
                notes = $"Lower weight! - {currentWeightUsed} Kg";
            }
            else if (currentTotalVolume <= _previousTotalVolume)
            {
                failAttempts = _lastStrikeCount == maxFailAttempts ? 0 : _lastStrikeCount + 1;

                if (failAttempts <= maxFailAttempts)
                {
                    notes = $"Keep going! - {currentWeightUsed} Kg";
                }

                if (_lastStrikeCount == maxFailAttempts)
                {
                    failAttempts = 0;
                    notes = $"Lower weight! - {currentWeightUsed} Kg";
                }

                var progressiveTotalVolume = CalculateProgressiveTotalVolume((int)minSets, (int)maxReps, currentWeightUsed);

                if (currentTotalSets >= minSets &&
                    currentTotalVolume >= progressiveTotalVolume &&
                    !anySetsUnderMaxReps)
                {
                    failAttempts = 0;
                    notes = $"Increase weight! - {currentWeightUsed} Kg";
                }
            }
            else
            {
                failAttempts = 0;

                if (totalReps / maxReps >= _trackList.Count)
                {
                    if (!anySetsUnderMaxReps)
                    {
                        notes = $"Increase weight! - {currentWeightUsed} Kg";
                    }
                    else
                    {
                        failAttempts++;
                        notes = $"Getting there! - {currentWeightUsed} Kg";
                    }
                }
                else
                {
                    notes = $"Getting there! - {currentWeightUsed} Kg";
                }
            }



            return new RulesResultViewModel
            {
                FailCount = failAttempts,
                Notes = notes
            };
        }

        private bool IsProgress(int exerciseId, decimal weight)
        {
            var item = _progressiveOverloadRepository
                .Find(x => x.ExerciseId == exerciseId && weight == x.Weight && x.IsActive == true)
                .FirstOrDefault();

            if (item != null)
            {
                var counter = item.Counter;
                
            }

            return false;
        }

        private void SaveProgressiveOverload(int counter, int exerciseId,
            int intervalId, decimal weight, bool isActive)
        {
            ProgressiveOverload po = new()
            {
                Counter = counter,
                ExerciseId = exerciseId,
                LogDate = DateTime.Now,
                RepRangeIntervalId = intervalId,
                Weight = weight,
                IsActive = isActive
            };

            _progressiveOverloadRepository.Add(po);
            _progressiveOverloadRepository.Commit();
        }

        private decimal CalculateProgressiveTotalVolume(int minSets, int maxReps, decimal weight)
        {
            decimal totalVolume = 0;

            for (int i = 1; i <= minSets; i++)
            {
                totalVolume += maxReps * weight;
            }

            return totalVolume;
        }

        private void ResetControls()
        {
            _workingExerciseId = 0;
            _exerciseId = 0;
            _exerciseMultiplier = 0;
            exerciseSettings = null!;
            _trackList.Clear();
            txtNotes.Clear();
            txtReps.Clear();
            txtWeight.Clear();
            lstTrack.DataSource = _trackList;
            dtWorkingDate.Value = DateTime.Today.AddDays(1).AddSeconds(-1);
            dtWorkingDate.Value = DateTime.Now;
            _dataPoints.Clear();
        }

        private void SetMainFormButtonEnabled(bool enabled)
        {
            _mainForm.TrackBtn.Enabled = enabled;
            _mainForm.BeginWorkoutBtn.Enabled = enabled;
            _mainForm.SettingsBtn.Enabled = enabled;
            _mainForm.DatabaseBtn.Enabled = enabled;
            _mainForm.WorkoutsBtn.Enabled = enabled;
        }

        private void SetupWorkoutButtons()
        {
            var activeWorkoutId = Session.Instance.ActiveWorkoutId;

            if (activeWorkoutId != null && activeWorkoutId > 0)
            {
                AddToButton.Visible = false;
                RemoveFromButton.Visible = true;
            }
            else
            {
                AddToButton.Visible = true;
                RemoveFromButton.Visible = false;
            }
        }

        private int CreateInitialWorkingExercise()
        {
            if (_exerciseId > 0)
            {
                var workingExercise = new WorkingExercise
                {
                    ExerciseId = _exerciseId,
                    FailCount = 0,
                    Notes = string.Empty,
                    WorkingDate = dtWorkingDate.Value
                };

                _workingExerciseId = _trackService.CreateWorkingExercise(workingExercise);
                return _workingExerciseId;
            }

            return 0;
        }

        private void AddWorkingExerciseToWorkout(int workingExerciseId)
        {
            var activeWorkoutId = Session.Instance.ActiveWorkoutId;

            if (activeWorkoutId != null && activeWorkoutId > 0)
            {
                _workoutService.AddWorkingExerciseToWorkout((int)activeWorkoutId, workingExerciseId);
            }
        }

        private void RemoveFromButton_Click(object sender, EventArgs e)
        {
            var responseMessage = MessageBox.Show("Are you sure?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (responseMessage == DialogResult.Yes)
            {
                var activeWorkoutId = Session.Instance.ActiveWorkoutId;

                _workoutService.RemoveWorkingExerciseFromWorkout(activeWorkoutId ?? 0, _workingExerciseId);

                RemoveFromButton.Visible = false;
                AddToButton.Visible = true;
            }
        }

        private void AddToButton_Click(object sender, EventArgs e)
        {
            var activeWorkoutId = Session.Instance.ActiveWorkoutId;

            if (activeWorkoutId != null && activeWorkoutId > 0)
            {
                if (_workingExerciseId > 0)
                {
                    AddWorkingExerciseToWorkout(_workingExerciseId);

                    RemoveFromButton.Visible = true;
                    AddToButton.Visible = false;
                }
                else
                {
                    MessageBox.Show("There seems to be a problem. The WorkingExerciseId is not set!");
                }
            }
            else
            {
                var messageResponse = MessageBox.Show("Would you like to begin a workout?", "Notice", MessageBoxButtons.OKCancel);

                if (messageResponse == DialogResult.OK)
                {
                    TriggerButtonEvent?.Invoke(this, EventArgs.Empty);

                    AddWorkingExerciseToWorkout(_workingExerciseId);

                    RemoveFromButton.Visible = true;
                    AddToButton.Visible = false;

                    SetUpdateWorkoutDateButton();
                }
            }
        }

        private void UpdateWorkoutDateButton_Click(object sender, EventArgs e)
        {
            var workoutId = Session.Instance.ActiveWorkoutId;
            var workoutDate = dtWorkingDate.Value;

            _workoutService.UpdateWorkoutDate(workoutId ?? 0, workoutDate);

            MessageBox.Show("Workout date has been updated!");
        }

        private void dtWorkingDate_ValueChanged(object sender, EventArgs e)
        {
            SetUpdateWorkoutDateButton();
        }

        private void LoadLastWorkingExerciseNotes()
        {
            var exerciseNotes = _trackService.GetTrackingNotes(_exerciseId);

            if (exerciseNotes != null)
            {
                groupNotes.Visible = true;

                var strikeCount = exerciseNotes.StrikeCount;
                var notes = exerciseNotes.Notes;

                _lastStrikeCount = strikeCount;

                var displayStrikes = string.Empty;

                if (strikeCount > 0)
                {
                    for (int i = 0; i < strikeCount; i++)
                    {
                        displayStrikes += "❌";
                    }

                    lblStrikes.ForeColor = Color.Red;
                }
                else
                {
                    displayStrikes = "N/A";
                    lblStrikes.ForeColor = Color.DarkGreen;
                }

                txtNotes.Text = notes;
                lblStrikes.Text = displayStrikes;
            }
            else
            {
                groupNotes.Visible = false;
            }
        }

        private void LoadLastTracking()
        {
            var lastTracking = _trackService.GetLastTracking(_exerciseId);

            if (lastTracking != null)
            {
                groupLastTracking.Visible = true;

                lblTotalVolume.Text = $"{lastTracking.TotalVolume} Kg";
                lblWorkingDate.Text = lastTracking.WorkingDate.ToString("MMM dd, yyyy");

                _previousTotalVolume = lastTracking.TotalVolume;

                SetupExerciseSetLables(lastTracking.TotalSets, true);
                SetLabelsData(lastTracking.TotalSets, lastTracking.WorkingSets);
            }
            else
            {
                groupLastTracking.Visible = false;
            }
        }

        private void SetupExerciseSetLables(int numberOfSets, bool isVisible)
        {
            for (int i = 1; i <= numberOfSets; i++)
            {
                if (Controls.Find($"lblSet{i}Display", true).FirstOrDefault() is Label displayLabel)
                {
                    displayLabel.Visible = isVisible;
                }

                if (Controls.Find($"lblSet{i}Data", true).FirstOrDefault() is Label dataLabel)
                {
                    dataLabel.Visible = isVisible;
                }
            }
        }

        private void SetLabelsData(int numberOfSets, List<LastWorkingSetViewModel> workingSets)
        {
            for (int i = 1; i <= numberOfSets; i++)
            {
                var set = workingSets.FirstOrDefault(x => x.SetNumber == i);

                if (Controls.Find($"lblSet{i}Data", true).FirstOrDefault() is Label dataLabel)
                {
                    dataLabel.Text = string.Format("R{0} x W{1}{2}", set.Reps, set.Weight, (set.Multiplier > 1 ? $" x {set.Multiplier}" : string.Empty));
                }
            }
        }

        private void txtReps_TextChanged(object sender, EventArgs e)
        {
            CalculateVolume();
        }

        private void txtWeight_TextChanged(object sender, EventArgs e)
        {
            CalculateVolume();
        }

        private void CalculateVolume()
        {
            var validRepsValue = int.TryParse(txtReps.Text, out int reps);
            var validWeightValue = decimal.TryParse(txtWeight.Text, out decimal weight);

            if (validRepsValue && validWeightValue)
            {
                var volume = reps * weight;
                txtVolume.Text = volume.ToString();
            }
            else
            {
                txtVolume.Clear();
            }

            var isValidVolume = decimal.TryParse(txtVolume.Text, out decimal setVolume);

            AddToTrackButton.Enabled = isValidVolume && setVolume > 0;
        }

        private void AddToTrackButton_Click(object sender, EventArgs e)
        {
            var trackListItemCount = lstTrack.Items.Count;

            _currentWeightUsed = decimal.Parse(txtWeight.Text);

            _trackList.Add(new TrackListViewModel
            {
                Display = string.Format("{0} x {1} Kg {2}", txtReps.Text, txtWeight.Text, _exerciseMultiplier > 1 ? "x 2" : string.Empty),
                Reps = int.Parse(txtReps.Text),
                SetNumber = trackListItemCount + 1,
                Weight = _currentWeightUsed
            });

            var currentTotalVolume = _trackList.Sum(x => x.Reps * x.Weight * _exerciseMultiplier);
            lblTotalInWorkVolume.Text = $"{currentTotalVolume} Kg";

            txtReps.Clear();

            LoadTimeRestForm();
        }

        private void LoadTimeRestForm()
        {
            var toolTimer = _toolTimerRepository.GetAll().FirstOrDefault();

            if (toolTimer != null)
            {
                var showTimer = toolTimer.IsDisplayed;

                if (showTimer)
                {
                    TimerForm timerForm = new();

                    timerForm.ShowDialog();
                }
            }
        }

        private void LoadWorkingExerciseHistory()
        {
            var history = _trackService.GetWorkingExerciseHistory(_exerciseId);
            var dataTable = _trackService.ConvertToDataTable(history);

            _dataPoints = ConvertFromDataTableToList(dataTable);
            _dataPoints = [.. _dataPoints.OrderBy(x => x.Date)];

            ViewGraphButton.Enabled = (_dataPoints != null && _dataPoints.Count > 0);

            dgvHistory.DataSource = dataTable;
        }

        private List<GraphViewModel> ConvertFromDataTableToList(DataTable dataTable)
        {
            List<GraphViewModel> graphViewModels = [];

            foreach (DataRow row in dataTable.Rows)
            {
                GraphViewModel graphViewModel = new GraphViewModel
                {
                    Date = Convert.ToDateTime(row["Date"]),
                    Volume = CleanVolumeData(row["Volume"]?.ToString() ?? "0")
                };

                graphViewModels.Add(graphViewModel);
            }

            return graphViewModels;
        }

        private decimal CleanVolumeData(string volData)
        {
            volData = volData.Replace("Kg", "");
            volData = volData.Trim();

            return Convert.ToDecimal(volData);
        }

        private void ViewGraphButton_Click(object sender, EventArgs e)
        {
            if (_dataPoints != null && _dataPoints.Count > 0)
            {
                WorkingExerciseGraph workingExerciseGraph = new(_dataPoints);

                workingExerciseGraph.ShowDialog();
            }
        }

        private void lstTrack_ItemAdded(object sender, EventArgs e)
        {
            if (lstTrack.Items.Count > 0)
            {
                RepeatLastButton.Enabled = true;
                RemoveFromTrackButton.Enabled = true;
            }
        }

        private void SetButtonTooltip()
        {
            tlpAddToTrack.SetToolTip(AddToTrackButton, "Add To Track");
            tlpAddToTrack.SetToolTip(RemoveFromTrackButton, "Remove From Track");
        }

        private void RemoveFromTrackButton_Click(object sender, EventArgs e)
        {
            if (lstTrack.SelectedItem != null)
            {
                _trackList.Remove((TrackListViewModel)lstTrack.SelectedItem);

                if (lstTrack.Items.Count == 0)
                {
                    RepeatLastButton.Enabled = false;
                    RemoveFromTrackButton.Enabled = false;
                }
            }
        }

        private void RepeatLastButton_Click(object sender, EventArgs e)
        {
            if (_trackList.Count > 0)
            {
                TrackListViewModel lastItem = _trackList[_trackList.Count - 1];

                if (lastItem != null)
                {
                    txtReps.Text = lastItem.Reps.ToString();
                    txtWeight.Text = lastItem.Weight.ToString();

                    AddToTrackButton_Click(this, EventArgs.Empty);
                }
            }
        }
    }
}
