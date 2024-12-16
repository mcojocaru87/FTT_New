using FTT.DataAccesss;
using FTT.DbEntity;
using FTT.GraphScreen;
using FTT.Services;
using FTT.Services.ExerciseWLoad;
using FTT.Services.RepRange;
using FTT.Services.Track;
using FTT.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using System.Data;

namespace FTT.UserControls
{
    public partial class TrackUC : UserControl
    {
        private readonly IRepository<Exercise>? exerciseRepository = RegisteredServiceProvider.Instance.ExerciseRepository;
        private readonly IRepository<Setting> _settingRepository;
        private readonly IRepository<ToolTimer> _toolTimerRepository;
        private readonly IRepository<ProgressiveOverload> _progressiveOverloadRepository;
        private readonly IRepository<ProgressiveOverloadAudit> _poAuditRepository;
        private readonly IRepository<Equipment> _equipmentRepository;
        private readonly IRepository<SlowProgressTrack> _slowProgressTrackRepository;
        private readonly ITrackService _trackService;
        private readonly IWorkoutService? _workoutService;
        private readonly IExerciseLoadService _exerciseLoadService;
        private readonly MainForm _mainForm;

        private bool _isWorkingExerciseInSession;
        private int _exerciseId;
        private int _exerciseMultiplier;
        private BindingList<TrackListViewModel> _trackList = [];
        private int _workingExerciseId = 0;
        private decimal _previousTotalVolume = 0;
        private decimal _currentWeightUsed = 0;
        private List<GraphViewModel> _dataPoints;
        private Setting exerciseSettings = null!;
        private bool isDumbbellUsed = false;
        private decimal todayUsedWeight = 0;

        public int RepRangeIntervalId { get; set; }

        public event EventHandler TriggerButtonEvent;

        private readonly IRepRangeService _repRangeService = RegisteredServiceProvider.Instance.RepRangeService!;

        public TrackUC(MainForm mainForm)
        {
            InitializeComponent();

            _trackService = Session.Instance.ServiceProvider.GetRequiredService<ITrackService>();
            _workoutService = RegisteredServiceProvider.Instance.WorkoutService;
            _exerciseLoadService = Session.Instance.ServiceProvider.GetRequiredService<IExerciseLoadService>();
            _settingRepository = Session.Instance.ServiceProvider.GetRequiredService<IRepository<Setting>>();
            _toolTimerRepository = Session.Instance.ServiceProvider.GetRequiredService<IRepository<ToolTimer>>();
            _progressiveOverloadRepository = Session.Instance.ServiceProvider.GetRequiredService<IRepository<ProgressiveOverload>>();
            _poAuditRepository = Session.Instance.ServiceProvider.GetRequiredService<IRepository<ProgressiveOverloadAudit>>();
            _equipmentRepository = Session.Instance.ServiceProvider.GetRequiredService<IRepository<Equipment>>();
            _slowProgressTrackRepository = Session.Instance.ServiceProvider.GetRequiredService<IRepository<SlowProgressTrack>>();

            _isWorkingExerciseInSession = false;
            _mainForm = mainForm;

            FinishButton.Enabled = false;
            CancelButton.Enabled = false;
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
            var exercises = exerciseRepository?.GetAll()
                .OrderByDescending(x => x.Category)
                .Select(x => new ComboBoxViewModel(x.Id, $"{x.Category} - {x.Name}"))
                .ToList();

            exercises?.Add(new(null, ""));

            cbExercises.DataSource = exercises;

            cbExercises.ValueMember = "ValueMember";
            cbExercises.DisplayMember = "DisplayMember";
        }

        private void LoadEquipmentItems(int equipmentId)
        {
            cbWeight.DataSource = null;

            var equipment = _equipmentRepository
                .GetById(equipmentId, true, "Items");

            if (equipment != null &&
                equipment.Items != null &&
                equipment.Items.Count > 0)
            {
                var dataSource = equipment.Items
                    .Select(x => new ComboBoxViewModel(x.Weight, x.Weight.ToString()))
                    .ToList();

                dataSource.Add(new(0M, 0.ToString()));

                dataSource = [.. dataSource.OrderBy(x => x.ValueMember)];

                cbWeight.DataSource = dataSource;
                cbWeight.DisplayMember = "DisplayMember";
                cbWeight.ValueMember = "ValueMember";
                cbWeight.Visible = true;
            }
            else
            {
                cbWeight.Visible = false;
            }
        }

        private void cbExercises_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetExerciseSetLabels();

            if (!_isWorkingExerciseInSession)
            {
                if (cbExercises.SelectedItem is ComboBoxViewModel selectedExercise && selectedExercise.ValueMember != null)
                {
                    _exerciseId = (int)selectedExercise.ValueMember;

                    var exercise = exerciseRepository?.GetById(_exerciseId);

                    if (exercise != null)
                    {
                        _exerciseMultiplier = exercise.Multiplier;

                        var equipmentUsed = _equipmentRepository
                            .GetById(exercise.EquipmentId);

                        if (equipmentUsed != null)
                        {
                            LoadEquipmentItems(exercise.EquipmentId);

                            isDumbbellUsed = equipmentUsed.IsDumbbell;
                        }
                    }

                    exerciseSettings = LoadExerciseSettings(_exerciseId);
                    SetRepRangeIntervalId();

                    StartButton.Visible = true;
                    FinishButton.Visible = true;
                    CancelButton.Visible = true;

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
                    CancelButton.Visible = false;
                    groupNotes.Visible = false;
                    groupLastTracking.Visible = false;
                    MainPanel.Visible = false;
                }
            }
        }

        private void SetRepRangeIntervalId()
        {
            var minReps = exerciseSettings.MinReps;
            var maxReps = exerciseSettings.MaxReps;

            var interval = _repRangeService.GetIntervalByRange(minReps, maxReps);

            RepRangeIntervalId = interval?.Id ?? 0;
        }

        private Setting LoadExerciseSettings(int exerciseId)
        {
            return _settingRepository
                .Find(x => x.ExerciseId == exerciseId)
                .FirstOrDefault()!;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            _isWorkingExerciseInSession = true;

            StartButton.Enabled = false;
            FinishButton.Enabled = true;
            CancelButton.Enabled = true;
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
            txtReps.Focus();

            SetMainFormButtonEnabled(false);
        }

        private void SetRepRangeIntervalLabel()
        {
            if (exerciseSettings != null)
            {
                var minReps = exerciseSettings.MinReps;
                var maxReps = exerciseSettings.MaxReps;

                lblIntervalInUse.Text = $"{minReps} - {maxReps}";
                lblMinSets.Text = exerciseSettings.MinSets.ToString();
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
            CancelButton.Enabled = false;
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
                RepRangeIntervalId = RepRangeIntervalId,
                WorkingDate = dtWorkingDate.Value
            };

            _trackService.FinishWorkingExercise(workingExercise);

            ResetControls();
        }

        private RulesResultViewModel RulesOfProgression()
        {
            var exerciseSettings = this.exerciseSettings;
            var maxReps = exerciseSettings?.MaxReps ?? 0;
            var minReps = exerciseSettings?.MinReps ?? 0;
            var minSets = exerciseSettings?.MinSets ?? 0;
            var notes = string.Empty;
            var currentWeightUsed = _trackList.Min(x => x.Weight);
            var currentTotalSets = _trackList.Count;
            var totalReps = _trackList.Sum(x => x.Reps);
            decimal loggedWeight = 0;
            bool isProgress = false;
            var intervalId = exerciseSettings?.RepRangeIntervalId ?? 0;
            var progressTrys = exerciseSettings?.ProgressTrys ?? 0;
            var currentTotalVolume = _trackList.Sum(x => x.Reps * x.Weight * _exerciseMultiplier);

            // 1. If first set is >= to exerciseSettings?.MinReps => Keep going
            var firstSet = _trackList.FirstOrDefault();
            var lastSet = _trackList.LastOrDefault();

            if (firstSet != null)
            {
                if (firstSet.Reps >= minReps)
                {
                    notes = $"Keep going! - {currentWeightUsed} Kg";
                }
                else
                {
                    notes = $"Lower weight! - {currentWeightUsed} Kg";

                    var nextLoad = _exerciseLoadService.GetNextLoad(currentWeightUsed, isDumbbellUsed, false);

                    if (nextLoad != null)
                    {
                        notes = (nextLoad.IsMin) ?
                            $"Min reached - {nextLoad.Weight} Kg" :
                            $"Lower weight to : {nextLoad.Weight} Kg";

                        loggedWeight = nextLoad.Weight;
                    }
                }
            }

            if (currentTotalSets >= minSets)
            {
                if (totalReps / maxReps >= _trackList.Count)
                {
                    if (lastSet != null && lastSet.Reps >= maxReps + 2)
                    {
                        notes = $"Increase weight! - {currentWeightUsed} Kg";

                        var nextLoad = _exerciseLoadService.GetNextLoad(currentWeightUsed, isDumbbellUsed, true);

                        if (nextLoad != null)
                        {
                            notes = (nextLoad.IsMax) ?
                                $"Max reached - {nextLoad.Weight} Kg" :
                                $"Increase weight to : {nextLoad.Weight} Kg";

                            loggedWeight = nextLoad.Weight;

                            isProgress = true;
                        }
                    }
                }
            }

            // Check if progress is made
            if (isProgress)
            {
                Session.Instance.IsActiveWorkoutProgressMade = true;
            }
            else
            {
                if (currentTotalVolume > _previousTotalVolume)
                {
                    Session.Instance.IsActiveWorkoutProgressMade = true;
                }
            }

            var counter = isProgress ? 1 : 0;

            SaveProgressiveOverload(counter, _exerciseId, intervalId,
                currentWeightUsed, string.Join(',', _trackList.Select(x => x.Reps)), progressTrys);

            if (loggedWeight == 0)
            {
                loggedWeight = currentWeightUsed;
            }

            _exerciseLoadService.UpdateExerciseLoad(_exerciseId, loggedWeight, notes);

            return new RulesResultViewModel
            {
                FailCount = 0,
                Notes = notes
            };
        }

        private void SaveProgressiveOverload(int counter, int exerciseId,
            int intervalId, decimal weight, string setsInfo, int progressTrys)
        {
            var progress = _progressiveOverloadRepository
                .Find(x => x.ExerciseId == exerciseId &&
                    x.Weight == weight &&
                    x.RepRangeIntervalId == intervalId)
                .FirstOrDefault();

            var isActive = true;

            if (progress != null)
            {
                isActive = progress.IsActive;
            }

            if (progress != null && isActive)
            {
                // update record

                var progressCounter = progress.Counter;

                progress.Counter = progressCounter + counter;
                progress.IsActive = progress.Counter < progressTrys;
                progress.LogDate = DateTime.Now;
                progress.SetsInfo = setsInfo;

                _progressiveOverloadRepository.Update(progress);
                _progressiveOverloadRepository.Commit();

                var newPoAudit = new ProgressiveOverloadAudit
                {
                    Counter = progress.Counter,
                    ExerciseId = progress.ExerciseId,
                    IsActive = progress.IsActive,
                    SetsInfo = progress.SetsInfo,
                    LogDate = progress.LogDate,
                    RepRangeIntervalId = progress.RepRangeIntervalId,
                    Weight = progress.Weight
                };

                CapturePOAudit(newPoAudit);
            }
            else
            {
                // create record

                ProgressiveOverload po = new()
                {
                    Counter = counter,
                    ExerciseId = exerciseId,
                    LogDate = DateTime.Now,
                    RepRangeIntervalId = intervalId,
                    Weight = weight,
                    IsActive = isActive,
                    SetsInfo = setsInfo
                };

                _progressiveOverloadRepository.Add(po);
                _progressiveOverloadRepository.Commit();

                var newPoAudit = new ProgressiveOverloadAudit
                {
                    Counter = po.Counter,
                    ExerciseId = po.ExerciseId,
                    IsActive = po.IsActive,
                    SetsInfo = po.SetsInfo,
                    LogDate = po.LogDate,
                    RepRangeIntervalId = po.RepRangeIntervalId,
                    Weight = po.Weight
                };

                CapturePOAudit(newPoAudit);
            }
        }

        private void CapturePOAudit(ProgressiveOverloadAudit record)
        {
            _poAuditRepository.Add(record);
            _poAuditRepository.Commit();
        }

        private void ResetControls()
        {
            _workingExerciseId = 0;
            _exerciseId = 0;
            _exerciseMultiplier = 0;
            exerciseSettings = null!;
            isDumbbellUsed = false;
            todayUsedWeight = 0;
            _trackList.Clear();
            txtNotes.Clear();
            txtReps.Clear();
            txtWeight.Clear();
            cbWeight.Visible = false;
            cbWeight.DataSource = null;
            lblTotalInWorkVolume.Text = "0";
            lblIntervalInUse.Text = string.Empty;
            lblMinSets.Text = string.Empty;
            lstTrack.DataSource = _trackList;
            dtWorkingDate.Value = DateTime.Today.AddDays(1).AddSeconds(-1);
            dtWorkingDate.Value = DateTime.Now;
            _dataPoints.Clear();
            RepRangeIntervalId = 0;
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
                _workoutService?.AddWorkingExerciseToWorkout((int)activeWorkoutId, workingExerciseId);
            }
        }

        private void RemoveFromButton_Click(object sender, EventArgs e)
        {
            var responseMessage = MessageBox.Show("Are you sure?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (responseMessage == DialogResult.Yes)
            {
                var activeWorkoutId = Session.Instance.ActiveWorkoutId;

                _workoutService?.RemoveWorkingExerciseFromWorkout(activeWorkoutId ?? 0, _workingExerciseId);

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

            _workoutService?.UpdateWorkoutDate(workoutId ?? 0, workoutDate);

            MessageBox.Show("Workout date has been updated!");
        }

        private void dtWorkingDate_ValueChanged(object sender, EventArgs e)
        {
            SetUpdateWorkoutDateButton();
        }

        private void LoadLastWorkingExerciseNotes()
        {
            var exerciseNotes = _trackService.GetTrackingNotes(_exerciseId, RepRangeIntervalId);

            if (exerciseNotes != null)
            {
                groupNotes.Visible = true;

                var notes = exerciseNotes.Notes;
                txtNotes.Text = notes;
            }
            else
            {
                groupNotes.Visible = false;
            }
        }

        private void LoadLastTracking()
        {
            var lastTracking = _trackService.GetLastTracking(_exerciseId, RepRangeIntervalId);
            decimal lastTrackedWeight = 0;

            if (lastTracking != null)
            {
                groupLastTracking.Visible = true;

                lblTotalVolume.Text = $"{lastTracking.TotalVolume} Kg";
                lblWorkingDate.Text = lastTracking.WorkingDate.ToString("MMM dd, yyyy");

                _previousTotalVolume = lastTracking.TotalVolume;

                SetupExerciseSetLables(lastTracking.TotalSets, true);
                SetLabelsData(lastTracking.TotalSets, lastTracking.WorkingSets);

                if (lastTracking.WorkingSets != null && lastTracking.WorkingSets.Count > 0)
                {
                    lastTrackedWeight = lastTracking.WorkingSets.Min(x => x.Weight);
                }
            }
            else
            {
                groupLastTracking.Visible = false;
            }

            LoadTodayWeightUsed(_exerciseId, lastTrackedWeight);
        }

        private void LoadTodayWeightUsed(int exerciseId, decimal lastTrackedWeight)
        {
            var exerciseLoad = _exerciseLoadService.GetExerciseLoadByExerciseId(exerciseId);

            if (exerciseLoad != null)
            {
                todayUsedWeight = exerciseLoad.CurrentLoad;
                txtWeight.Text = exerciseLoad.CurrentLoad.ToString();
                cbWeight.SelectedValue = exerciseLoad.CurrentLoad;
            }
            else
            {
                if (lastTrackedWeight == 0)
                {
                    txtWeight.Clear();
                    cbWeight.SelectedValue = 0;
                }
                else
                {
                    txtWeight.Text = lastTrackedWeight.ToString();
                    cbWeight.SelectedValue = lastTrackedWeight;
                }
            }
        }

        private void ResetExerciseSetLabels()
        {
            for (int i = 1; i <= 6; i++)
            {
                if (Controls.Find($"lblSet{i}Display", true).FirstOrDefault() is Label displayLabel)
                {
                    displayLabel.Visible = false;
                }

                if (Controls.Find($"lblSet{i}Data", true).FirstOrDefault() is Label dataLabel)
                {
                    dataLabel.Visible = false;
                    dataLabel.Text = string.Empty;
                }
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
                    dataLabel.Text = string.Format("R{0} x W{1}{2}", set?.Reps, set?.Weight, (set?.Multiplier > 1 ? $" x {set.Multiplier}" : string.Empty));
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

        private void cbWeight_SelectedValueChanged(object sender, EventArgs e)
        {
            var isCbWeightVisible = cbWeight.Visible == true;

            if (isCbWeightVisible)
            {
                CalculateVolume();
            }
        }

        private void CalculateVolume()
        {
            var validRepsValue = int.TryParse(txtReps.Text, out int reps);
            bool validWeightValue;
            decimal weight;

            if (cbWeight.Visible == true)
            {
                weight = (decimal)cbWeight.SelectedValue!;
                validWeightValue = weight > 0;
            }
            else
            {
                validWeightValue = decimal.TryParse(txtWeight.Text, out weight);
            }

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

            _currentWeightUsed = (cbWeight.Visible == true) ?
                (decimal)cbWeight.SelectedValue! :
                decimal.Parse(txtWeight.Text);

            _trackList.Add(new TrackListViewModel
            {
                Display = string.Format("{0} x {1} Kg {2}", txtReps.Text, _currentWeightUsed, _exerciseMultiplier > 1 ? "x 2" : string.Empty),
                Reps = int.Parse(txtReps.Text),
                SetNumber = trackListItemCount + 1,
                Weight = _currentWeightUsed
            });

            var currentTotalVolume = _trackList.Sum(x => x.Reps * x.Weight * _exerciseMultiplier);
            lblTotalInWorkVolume.Text = $"{currentTotalVolume} Kg";

            txtReps.Clear();
            txtReps.Focus();

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
                    var exerciseSets = exerciseSettings.MinSets;
                    var workingSets = _trackList.Count;

                    bool showExercises = workingSets >= exerciseSets;

                    TimerForm timerForm = new(showExercises);

                    timerForm.ShowDialog();
                }
            }
        }

        private void LoadWorkingExerciseHistory()
        {
            var history = _trackService.GetWorkingExerciseHistory(_exerciseId, RepRangeIntervalId);
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
                    cbWeight.SelectedValue = lastItem.Weight;

                    AddToTrackButton_Click(this, EventArgs.Empty);
                }
            }
        }

        private void txtReps_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Prevent the beep sound
                e.SuppressKeyPress = true;

                if (txtReps.Text.Length > 0 &&
                    (txtWeight.Text.Length > 0 || (decimal)cbWeight.SelectedValue! > 0) &&
                    txtVolume.Text.Length > 0)
                {
                    // Trigger your event here
                    AddToTrackButton_Click(this, EventArgs.Empty);
                }
            }
        }

        private void txtWeight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Prevent the beep sound
                e.SuppressKeyPress = true;

                if (txtReps.Text.Length > 0 &&
                    txtWeight.Text.Length > 0 &&
                    txtVolume.Text.Length > 0)
                {
                    // Trigger your event here
                    AddToTrackButton_Click(this, EventArgs.Empty);
                }
            }
        }

        private void lblSwitchRange_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SwitchIntervalRangeForm switchIntervalRangeForm = new(_exerciseId, this);

            switchIntervalRangeForm.ShowDialog();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            if (_trackList.Count > 0)
            {
                var messageResponse = MessageBox.Show("Are you sure you want to cancel? There are some sets being tracked.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (messageResponse == DialogResult.No)
                {
                    return;
                }
            }

            _isWorkingExerciseInSession = false;

            FinishButton.Enabled = false;
            CancelButton.Enabled = false;
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

            ResetControls();
        }

        private void cbWeight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Prevent the beep sound
                e.SuppressKeyPress = true;

                if (txtReps.Text.Length > 0 &&
                    (txtWeight.Text.Length > 0 || (decimal)cbWeight.SelectedValue! > 0) &&
                    txtVolume.Text.Length > 0)
                {
                    // Trigger your event here
                    AddToTrackButton_Click(this, EventArgs.Empty);
                }
            }
        }


    }
}
