using FTT.DataAccesss;
using FTT.DbEntity;
using Microsoft.Extensions.DependencyInjection;

namespace FTT.UserControls
{
    public partial class SettingsUC : UserControl
    {
        private readonly IRepository<Setting> _settingsRepository;

        public SettingsUC()
        {
            InitializeComponent();

            _settingsRepository = Session.Instance.ServiceProvider.GetRequiredService<IRepository<Setting>>();

            SetDefaultSettingValues();
            LoadSettings();
        }

        public void SetDefaultSettingValues()
        {
            txtFailAttempts.Text = "4";
            txtMaxReps.Text = "12";
        }

        public void LoadSettings()
        {
            var settings = _settingsRepository.GetAll().ToList();

            if (settings.Count > 0)
            {
                ClearSettings();

                var defaultSettings = settings.First();

                txtFailAttempts.Text = defaultSettings.FailAttempts.ToString();
                txtMaxReps.Text = defaultSettings.MaxReps.ToString();

                Session.Instance.Settings = defaultSettings;
            }
        }

        private void ClearSettings()
        {
            txtFailAttempts.Clear();
            txtMaxReps.Clear();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            bool vaildFailAttemptsValue = int.TryParse(txtFailAttempts.Text, out int failAttempts);
            bool vaildMaxRepsValue = int.TryParse(txtMaxReps.Text, out int maxReps);

            if (vaildFailAttemptsValue && vaildMaxRepsValue)
            {
                if (Session.Instance.Settings != null)
                {
                    var settingId = Session.Instance.Settings.Id;

                    var currentSettings = _settingsRepository.GetById(settingId);

                    currentSettings.MaxReps = maxReps;
                    currentSettings.FailAttempts = failAttempts;

                    _settingsRepository.Update(currentSettings);
                    _settingsRepository.Commit();
                }
                else
                {
                    var newSettings = new Setting { FailAttempts = failAttempts, MaxReps = maxReps };

                    _settingsRepository.Add(newSettings);
                    _settingsRepository.Commit();

                    Session.Instance.Settings = newSettings;
                }

                MessageBox.Show("Settings have been updated!");
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
    }
}
