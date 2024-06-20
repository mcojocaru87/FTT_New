using FTT.DataAccesss;
using FTT.DbEntity;
using FTT.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace FTT.UserControls
{
    public partial class SettingsUC : UserControl
    {
        private readonly IRepository<Setting> _settingsRepository;
        private readonly IRepository<Exercise> _exerciseRepository;
        private readonly IRepository<ToolTimer> _toolTimerRepository;
        private readonly IRepository<RepRangeInterval> _repRangeIntervalRepository;

        private bool isCreateInstance = false;
        private bool isPreSet = false;
        private int exerciseId = 0;
        private int exerciseSettingsId = 0;
        private ToolTimer toolTimer = null!;

        public SettingsUC()
        {
            InitializeComponent();

            _settingsRepository = Session.Instance.ServiceProvider.GetRequiredService<IRepository<Setting>>();
            _exerciseRepository = Session.Instance.ServiceProvider.GetRequiredService<IRepository<Exercise>>();
            _toolTimerRepository = Session.Instance.ServiceProvider.GetRequiredService<IRepository<ToolTimer>>();
            _repRangeIntervalRepository = Session.Instance.ServiceProvider.GetRequiredService<IRepository<RepRangeInterval>>();

            SetupProgressTrys();
            LoadMinSets();
            LoadExercises();
            LoadTimerSettings();
            ResetMainPanel();
        }

        private void SetSettingsDefaults()
        {
            txtFailAttempts.Text = "4";
            txtMaxReps.Text = "8";
            txtMinReps.Text = "5";
            cbMinSets.SelectedValue = 3;
            cbProgressTrys.SelectedValue = 2;

            SaveButton.Text = "Create";
            lblMode.Text = "New";

            isCreateInstance = true;
        }

        public void LoadSettingsForExercise(int exerciseId)
        {
            var exerciseSettings = _settingsRepository
                .Find(x => x.ExerciseId == exerciseId)
                .FirstOrDefault();

            if (exerciseSettings != null)
            {
                txtFailAttempts.Text = exerciseSettings.FailAttempts.ToString();
                txtMaxReps.Text = exerciseSettings.MaxReps.ToString();
                txtMinReps.Text = exerciseSettings.MinReps.ToString();
                cbMinSets.SelectedValue = exerciseSettings.MinSets;
                cbProgressTrys.SelectedValue = exerciseSettings.ProgressTrys;

                if (exerciseSettings.RepRangeIntervalId > 0)
                {
                    cbIntervals.SelectedValue = exerciseSettings.RepRangeIntervalId;
                    IntervalsPanel.Visible = true;
                }
                else
                {
                    IntervalsPanel.Visible = false;

                    txtMaxReps.ReadOnly = false;
                    txtMinReps.ReadOnly = false;
                }

                exerciseSettingsId = exerciseSettings.Id;
                lblMode.Text = "Update";
            }
            else
            {
                SetSettingsDefaults();

                IntervalsPanel.Visible = false;

                txtMaxReps.ReadOnly = false;
                txtMinReps.ReadOnly = false;
            }
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

        private void LoadMinSets()
        {
            List<ComboBoxViewModel> dataSource = [];

            for (int i = 1; i <= 6; i++)
            {
                dataSource.Add(new(i, i.ToString()));
            }

            cbMinSets.DataSource = dataSource;
            cbMinSets.ValueMember = "ValueMember";
            cbMinSets.DisplayMember = "DisplayMember";
        }

        private void SetupProgressTrys()
        {
            List<ComboBoxViewModel> dataSource = [];

            for (int i = 1; i <= 10; i++)
            {
                dataSource.Add(new(i, i.ToString()));
            }

            cbProgressTrys.DataSource = dataSource;
            cbProgressTrys.ValueMember = "ValueMember";
            cbProgressTrys.DisplayMember = "DisplayMember";
        }

        private bool CheckIfRepRangeIntervalExists(int minReps, int maxReps)
        {
            var interval = _repRangeIntervalRepository
                .Find(x => x.MinReps == minReps && x.MaxReps == maxReps)
                .FirstOrDefault();

            return interval != null;
        }

        private RepRangeInterval GetIntervalByRange(int minReps, int maxReps)
        {
            return _repRangeIntervalRepository
                 .Find(x => x.MinReps == minReps && x.MaxReps == maxReps)
                 .FirstOrDefault();
        }

        private void UpdateExerciseSettingsInterval(int exerciseId, int minReps, int maxReps)
        {
            var exerciseSettings = _settingsRepository
                  .Find(x => x.ExerciseId == exerciseId)
                  .FirstOrDefault();

            var intervalId = CreateNewRepRangeInterval(minReps, maxReps);

            if (intervalId > 0)
            {
                if (exerciseSettings != null)
                {
                    exerciseSettings.RepRangeIntervalId = intervalId;

                    _settingsRepository.Update(exerciseSettings);
                    _settingsRepository.Commit();
                }
            }

            if (exerciseId > 0)
            {
                var interval = GetIntervalByRange(minReps, maxReps);

                if (interval != null)
                {
                    if (exerciseSettings != null)
                    {
                        exerciseSettings.RepRangeIntervalId = interval.Id;

                        _settingsRepository.Update(exerciseSettings);
                        _settingsRepository.Commit();
                    }
                }
            }
        }

        private int CreateNewRepRangeInterval(int minReps, int maxReps)
        {
            if (!CheckIfRepRangeIntervalExists(minReps, maxReps))
            {
                var newInterval = new RepRangeInterval
                {
                    MinReps = minReps,
                    MaxReps = maxReps
                };

                _repRangeIntervalRepository.Add(newInterval);
                _repRangeIntervalRepository.Commit();

                return newInterval.Id;
            }

            return 0;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            bool vaildFailAttemptsValue = int.TryParse(txtFailAttempts.Text, out int failAttempts);
            bool vaildMaxRepsValue = int.TryParse(txtMaxReps.Text, out int maxReps);
            bool validMinRepsValue = int.TryParse(txtMinReps.Text, out int minReps);

            int minSets = (int)cbMinSets.SelectedValue;
            int progressTrys = (int)cbProgressTrys.SelectedValue;

            if (vaildFailAttemptsValue &&
                vaildMaxRepsValue &&
                validMinRepsValue)
            {
                if (isCreateInstance && exerciseId > 0)
                {
                    var newSettings = new Setting
                    {
                        FailAttempts = failAttempts,
                        MaxReps = maxReps,
                        MinReps = minReps,
                        MinSets = minSets,
                        ExerciseId = exerciseId,
                        ProgressTrys = progressTrys,
                    };

                    _settingsRepository.Add(newSettings);
                    _settingsRepository.Commit();

                    UpdateExerciseSettingsInterval(newSettings.ExerciseId, newSettings.MinReps, newSettings.MaxReps);
                }
                else if (isPreSet)
                {
                    var allExercises = _exerciseRepository.GetAll().ToList();

                    var allExerciseSettings = _settingsRepository
                        .Find(x => x.ExerciseId > 0)
                        .ToList();

                    if (allExerciseSettings.Count < allExercises.Count)
                    {
                        foreach (var item in allExercises)
                        {
                            var exerciseId = item.Id;

                            var existingExerciseSettings = _settingsRepository
                                .Find(x => x.ExerciseId == exerciseId).FirstOrDefault();

                            if (existingExerciseSettings == null)
                            {
                                var newSettings = new Setting
                                {
                                    FailAttempts = failAttempts,
                                    MaxReps = maxReps,
                                    MinReps = minReps,
                                    MinSets = minSets,
                                    ExerciseId = exerciseId,
                                    ProgressTrys = progressTrys,
                                };

                                _settingsRepository.Add(newSettings);
                                _settingsRepository.Commit();

                                UpdateExerciseSettingsInterval(newSettings.ExerciseId, newSettings.MinReps, newSettings.MaxReps);
                            }
                        }
                    }

                    if (allExerciseSettings.Count > 0)
                    {
                        foreach (var item in allExerciseSettings)
                        {
                            item.MinReps = minReps;
                            item.MaxReps = maxReps;
                            item.MinSets = minSets;
                            item.FailAttempts = failAttempts;
                            item.ProgressTrys = progressTrys;

                            _settingsRepository.Update(item);

                            UpdateExerciseSettingsInterval(item.ExerciseId, item.MinReps, item.MaxReps);
                        }

                        _settingsRepository.Commit();
                    }
                }
                else
                {
                    var currentSettings = _settingsRepository.GetById(exerciseSettingsId);

                    if (currentSettings != null)
                    {
                        currentSettings.MaxReps = maxReps;
                        currentSettings.FailAttempts = failAttempts;
                        currentSettings.MinReps = minReps;
                        currentSettings.MinSets = minSets;
                        currentSettings.ProgressTrys = progressTrys;

                        _settingsRepository.Update(currentSettings);
                        _settingsRepository.Commit();

                        UpdateExerciseSettingsInterval(currentSettings.ExerciseId, currentSettings.MinReps, currentSettings.MaxReps);
                    }
                }

                MessageBox.Show("Settings have been updated!");
                ResetMainPanel();
            }
            else
            {
                MessageBox.Show("Settings could not be saved to due invalid values!");
            }
        }

        private void CleanupButton_Click(object sender, EventArgs e)
        {
            CleanupData cleanupData = new();

            cleanupData.ShowDialog();
        }

        private void cbExercises_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbExercises.SelectedItem is ComboBoxViewModel selectedExercise && selectedExercise.ValueMember != null)
            {
                exerciseId = (int)selectedExercise.ValueMember;

                LoadIntervals(exerciseId);
                LoadSettingsForExercise(exerciseId);

                PreSetButton.Enabled = false;
                MainPanel.Visible = true;
            }
            else
            {
                ResetMainPanel();
            }
        }

        private void ResetMainPanel()
        {
            txtFailAttempts.Clear();
            txtMaxReps.Clear();
            txtMinReps.Clear();
            cbMinSets.SelectedValue = 1;
            cbProgressTrys.SelectedValue = 2;
            cbExercises.SelectedValue = 0;

            MainPanel.Visible = false;
            SaveButton.Text = "Update";

            isCreateInstance = false;
            isPreSet = false;
            exerciseId = 0;
            exerciseSettingsId = 0;
            PreSetButton.Enabled = true;
            lblMode.Text = string.Empty;

            lblCancel.Visible = false;
            cbIntervals.Enabled = true;
            lblCustom.Visible = true;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            ResetMainPanel();
        }

        private void PreSetButton_Click(object sender, EventArgs e)
        {
            isPreSet = true;

            IntervalsPanel.Visible = false;

            txtFailAttempts.Text = "2";
            txtMaxReps.Text = "8";
            txtMinReps.Text = "5";
            txtMaxReps.ReadOnly = false;
            txtMinReps.ReadOnly = false;
            cbMinSets.SelectedValue = 1;
            cbProgressTrys.SelectedValue = 2;
            lblMode.Text = "Pre-Set";

            MainPanel.Visible = true;
            PreSetButton.Enabled = false;
        }

        private void LoadTimerSettings()
        {
            var toolTimer = _toolTimerRepository.GetAll().FirstOrDefault();

            this.toolTimer = toolTimer;

            if (toolTimer != null)
            {
                chkDisplayTimer.Checked = toolTimer.IsDisplayed;
            }
            else
            {
                chkDisplayTimer.Enabled = false;
                chkDisplayTimer.Checked = false;
            }
        }

        private void chkDisplayTimer_CheckedChanged(object sender, EventArgs e)
        {
            toolTimer.IsDisplayed = chkDisplayTimer.Checked;

            _toolTimerRepository.Update(toolTimer);
            _toolTimerRepository.Commit();
        }

        private void lblCustom_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lblCancel.Visible = true;
            txtMaxReps.ReadOnly = false;
            txtMinReps.ReadOnly = false;
            cbIntervals.Enabled = false;
            lblCustom.Visible = false;
        }

        private void lblCancel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lblCancel.Visible = false;
            txtMaxReps.ReadOnly = true;
            txtMinReps.ReadOnly = true;
            cbIntervals.Enabled = true;
            lblCustom.Visible = true;
        }

        private void LoadIntervals(int exerciseId)
        {
            var intervals = _repRangeIntervalRepository
                .GetAll().ToList();

            if (intervals.Count > 0)
            {
                var intervalsDataSource = intervals
                    .Select(x => new ComboBoxViewModel(x.Id, $"{x.MinReps} - {x.MaxReps}"))
                    .ToList();

                cbIntervals.DataSource = intervalsDataSource;

                cbIntervals.DisplayMember = "DisplayMember";
                cbIntervals.ValueMember = "ValueMember";

                IntervalsPanel.Visible = true;

                txtMinReps.ReadOnly = true;
                txtMaxReps.ReadOnly = true;
            }
            else
            {
                IntervalsPanel.Visible = false;
                cbIntervals.DataSource = null;
            }
        }

        private void cbIntervals_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbIntervals.SelectedItem is ComboBoxViewModel selectedInterval && selectedInterval.ValueMember != null)
            {
                var intervalId = (int)selectedInterval.ValueMember;

                LoadIntervalData(intervalId);
            }
        }

        private void LoadIntervalData(int intervalId)
        {
            var interval = _repRangeIntervalRepository.GetById(intervalId);

            if (interval != null)
            {
                txtMinReps.Text = interval.MinReps.ToString();
                txtMaxReps.Text = interval.MaxReps.ToString();
            }
        }
    }
}
