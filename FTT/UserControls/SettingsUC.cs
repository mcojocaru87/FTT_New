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

        private bool isCreateInstance = false;
        private bool isPreSet = false;
        private int exerciseId = 0;
        private int exerciseSettingsId = 0;

        public SettingsUC()
        {
            InitializeComponent();

            _settingsRepository = Session.Instance.ServiceProvider.GetRequiredService<IRepository<Setting>>();
            _exerciseRepository = Session.Instance.ServiceProvider.GetRequiredService<IRepository<Exercise>>();

            LoadExercises();
            ResetMainPanel();
        }

        private void SetSettingsDefaults()
        {
            txtFailAttempts.Text = "4";
            txtMaxReps.Text = "8";
            txtMinReps.Text = "5";
            txtMinSets.Text = "3";

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
                txtMinSets.Text = exerciseSettings.MinSets.ToString();

                exerciseSettingsId = exerciseSettings.Id;
                lblMode.Text = "Update";
            }
            else
            {
                SetSettingsDefaults();
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

        private void SaveButton_Click(object sender, EventArgs e)
        {
            bool vaildFailAttemptsValue = int.TryParse(txtFailAttempts.Text, out int failAttempts);
            bool vaildMaxRepsValue = int.TryParse(txtMaxReps.Text, out int maxReps);
            bool validMinRepsValue = int.TryParse(txtMinReps.Text, out int minReps);
            bool validMinSetsValue = int.TryParse(txtMinSets.Text, out int minSets);

            if (vaildFailAttemptsValue &&
                vaildMaxRepsValue &&
                validMinRepsValue &&
                validMinSetsValue)
            {
                if (isCreateInstance && exerciseId > 0)
                {
                    var newSettings = new Setting
                    {
                        FailAttempts = failAttempts,
                        MaxReps = maxReps,
                        MinReps = minReps,
                        MinSets = minSets,
                        ExerciseId = exerciseId
                    };

                    _settingsRepository.Add(newSettings);
                    _settingsRepository.Commit();
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
                                    ExerciseId = exerciseId
                                };

                                _settingsRepository.Add(newSettings);
                                _settingsRepository.Commit();
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

                            _settingsRepository.Update(item);
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

                        _settingsRepository.Update(currentSettings);
                        _settingsRepository.Commit();
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
            txtMinSets.Clear();
            cbExercises.SelectedValue = 0;

            MainPanel.Visible = false;
            SaveButton.Text = "Update";

            isCreateInstance = false;
            isPreSet = false;
            exerciseId = 0;
            exerciseSettingsId = 0;
            PreSetButton.Enabled = true;
            lblMode.Text = string.Empty;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            ResetMainPanel();
        }

        private void PreSetButton_Click(object sender, EventArgs e)
        {
            isPreSet = true;

            txtFailAttempts.Clear();
            txtMaxReps.Clear();
            txtMinReps.Clear();
            txtMinSets.Clear();
            lblMode.Text = "Pre-Set";

            MainPanel.Visible = true;
            PreSetButton.Enabled = false;
        }
    }
}
