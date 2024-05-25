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

        public event EventHandler TriggerButtonEvent;

        public TrackUC(MainForm mainForm)
        {
            InitializeComponent();

            _exerciseRepository = Session.Instance.ServiceProvider.GetRequiredService<IRepository<Exercise>>();
            _trackService = Session.Instance.ServiceProvider.GetRequiredService<ITrackService>();
            _workoutService = Session.Instance.ServiceProvider.GetRequiredService<IWorkoutService>();
            _settingRepository = Session.Instance.ServiceProvider.GetRequiredService<IRepository<Setting>>();

            _isWorkingExerciseInSession = false;
            _mainForm = mainForm;

            FinishButton.Enabled = false;
            dtWorkingDate.MaxDate = DateTime.Today.AddDays(1).AddSeconds(-1);
            AddToTrackButton.Enabled = false;

            lstTrack.DataSource = _trackList;
            lstTrack.DisplayMember = "Display";

            LoadExercises();
        }

        private void LoadExercises()
        {
            var exercises = _exerciseRepository.GetAll()
                .Select(x => new ComboBoxViewModel(x.Id, x.Name))
                .ToList();

            exercises.Add(new(null, ""));

            exercises = exercises.OrderBy(x => x.ValueMember).ToList();

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

            SetUpdateWorkoutDateButton();
            LoadWorkingExerciseHistory();

            MainPanel.Visible = true;

            SetMainFormButtonEnabled(false);
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

            SetMainFormButtonEnabled(true);
        }

        private void FinishWorkingExerciseSession()
        {
            var currentTotalVolume = _trackList.Sum(x => x.Reps * x.Weight * _exerciseMultiplier);
            var settings = _settingRepository.GetAll().FirstOrDefault();
            var currentWeightUsed = _trackList.First().Weight;
            var totalReps = _trackList.Sum(x => x.Reps);

            var maxFailAttempts = settings?.FailAttempts ?? 4;
            var maxReps = settings?.MaxReps ?? 12;
            var notes = string.Empty;
            var failAttempts = 0;

            if (currentTotalVolume <= _previousTotalVolume)
            {
                failAttempts = _lastStrikeCount == maxFailAttempts ? 0 : _lastStrikeCount + 1;

                if (failAttempts <= maxFailAttempts)
                {
                    notes = $"Keep going! - {currentWeightUsed} Kg";
                }

                if (_lastStrikeCount == maxFailAttempts)
                {
                    notes = $"Lower weight! - {currentWeightUsed} Kg";
                }
            }
            else
            {
                failAttempts = 0;

                notes = (totalReps / maxReps == _trackList.Count) ?
                        $"Increase weight! - {currentWeightUsed} Kg" :
                        $"Getting there! - {currentWeightUsed} Kg";
            }

            var workingExercise = new WorkingExercise
            {
                Id = _workingExerciseId,
                ExerciseId = _exerciseId,
                FailCount = failAttempts,
                Notes = notes,
                WorkingDate = dtWorkingDate.Value
            };

            _trackService.FinishWorkingExercise(workingExercise);

            ResetControls();
        }

        private void ResetControls()
        {
            _workingExerciseId = 0;
            _exerciseId = 0;
            _exerciseMultiplier = 0;
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
            }

            RemoveFromButton.Visible = false;
            AddToButton.Visible = true;
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

                SetupExerciseSetLables(lastTracking.TotalSets);
                SetLabelsData(lastTracking.TotalSets, lastTracking.WorkingSets);
            }
            else
            {
                groupLastTracking.Visible = false;
            }
        }

        private void SetupExerciseSetLables(int numberOfSets)
        {
            for (int i = 1; i <= numberOfSets; i++)
            {
                if (Controls.Find($"lblSet{i}Display", true).FirstOrDefault() is Label displayLabel)
                {
                    displayLabel.Visible = true;
                }

                if (Controls.Find($"lblSet{i}Data", true).FirstOrDefault() is Label dataLabel)
                {
                    dataLabel.Visible = true;
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

            txtReps.Clear();
        }

        private void LoadWorkingExerciseHistory()
        {
            var history = _trackService.GetWorkingExerciseHistory(_exerciseId);
            var dataTable = _trackService.ConvertToDataTable(history);

            _dataPoints = ConvertFromDataTableToList(dataTable);

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
    }
}
