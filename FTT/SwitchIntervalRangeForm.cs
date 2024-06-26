using FTT.DataAccesss;
using FTT.DbEntity;
using FTT.UserControls;
using FTT.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace FTT
{
    public partial class SwitchIntervalRangeForm : Form
    {
        private readonly IRepository<Exercise> _exerciseRepository;
        private readonly IRepository<RepRangeInterval> _repRangeIntervalRepository;
        private readonly IRepository<Setting> _settingsRepository;
        private readonly int _exerciseId;
        private readonly TrackUC _trackForm;

        private int currentIntervalId = 0;
        private int? selectedIntervalId = null!;

        public SwitchIntervalRangeForm(int exerciseId, TrackUC trackForm)
        {
            InitializeComponent();

            _exerciseRepository = Session.Instance.ServiceProvider.GetRequiredService<IRepository<Exercise>>();
            _repRangeIntervalRepository = Session.Instance.ServiceProvider.GetRequiredService<IRepository<RepRangeInterval>>();
            _settingsRepository = Session.Instance.ServiceProvider.GetRequiredService<IRepository<Setting>>();
            _exerciseId = exerciseId;
            _trackForm = trackForm;

            LoadExerciseData();
            LoadMinSets();
            LoadIntervalData();
            SetExerciseSettingsData();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            ResetForm();

            this.Dispose();
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (selectedIntervalId != null)
            {
                var exerciseSettings = _settingsRepository
                        .Find(x => x.ExerciseId == _exerciseId)
                        .FirstOrDefault();

                string selectedInterval = string.Empty;

                if (selectedIntervalId > 0)
                {
                    var interval = _repRangeIntervalRepository.GetById((int)selectedIntervalId);

                    UpdateExerciseSettings(exerciseSettings!, (int)selectedIntervalId,
                        interval.MaxReps, interval.MinReps, (int)cbMinSets.SelectedValue!);

                    selectedInterval = cbInterval.Text;
                }
                else
                {
                    var newInterval = new RepRangeInterval
                    {
                        MaxReps = int.Parse(txtMaxReps.Text),
                        MinReps = int.Parse(txtMinReps.Text)
                    };

                    _repRangeIntervalRepository.Add(newInterval);
                    _repRangeIntervalRepository.Commit();

                    UpdateExerciseSettings(exerciseSettings!, newInterval.Id,
                        newInterval.MaxReps, newInterval.MaxReps, (int)cbMinSets.SelectedValue!);

                    selectedInterval = $"{txtMinReps.Text} - {txtMaxReps.Text}";
                }

                Label lbl = (Label)_trackForm.Controls.Find("lblIntervalInUse", true).FirstOrDefault()!;
                Label lblMinSets = (Label)_trackForm.Controls.Find("lblMinSets", true).FirstOrDefault()!;

                if (lbl != null)
                {
                    lbl.Text = selectedInterval;
                }

                if (lblMinSets != null)
                {
                    lblMinSets.Text = cbMinSets.Text;
                }

                MessageBox.Show("Exercise interval has been updated!");

                CancelButton_Click(this, null!);
            }
        }

        private void UpdateExerciseSettings(Setting exerciseSettings, int intervalId, int maxReps, int minReps, int minSets)
        {
            if (exerciseSettings != null)
            {
                exerciseSettings.RepRangeIntervalId = intervalId;
                exerciseSettings.MaxReps = maxReps;
                exerciseSettings.MinReps = minReps;
                exerciseSettings.MinSets = minSets;

                _settingsRepository.Update(exerciseSettings);
                _settingsRepository.Commit();
            }
        }

        private void LoadExerciseData()
        {
            var exercise = _exerciseRepository.GetById(_exerciseId);

            if (exercise != null)
            {
                txtExerciseName.Text = exercise.Name;
            }
        }

        private void LoadIntervalData()
        {
            var intervals = _repRangeIntervalRepository
                .GetAll()
                .Select(x => new ComboBoxViewModel(x.Id, $"{x.MinReps} - {x.MaxReps}"))
                .ToList();

            intervals.Add(new ComboBoxViewModel(0, "Custom ..."));

            cbInterval.DataSource = intervals;

            cbInterval.DisplayMember = "DisplayMember";
            cbInterval.ValueMember = "ValueMember";
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

        private void SetExerciseSettingsData()
        {
            var exerciseSettings = _settingsRepository
                .Find(x => x.ExerciseId == _exerciseId)
                .FirstOrDefault();

            if (exerciseSettings != null)
            {
                cbInterval.SelectedValue = exerciseSettings.RepRangeIntervalId;
                currentIntervalId = exerciseSettings.RepRangeIntervalId;
                cbMinSets.SelectedValue = exerciseSettings.MinSets;
            }
        }

        private void ResetForm()
        {
            cbInterval.DataSource = null!;
            cbMinSets.DataSource = null!;
            txtExerciseName.Clear();
            txtMinReps.Clear();
            txtMaxReps.Clear();
            MainPanel.Visible = false;
            cbInterval.Enabled = true;
            lblCancelCustom.Visible = false;
        }

        private void cbInterval_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbInterval.SelectedItem is ComboBoxViewModel selectedInterval && selectedInterval.ValueMember != null)
            {
                selectedIntervalId = (int)selectedInterval.ValueMember;

                if ((int)selectedInterval.ValueMember == 0)
                {
                    txtMinReps.Clear();
                    txtMaxReps.Clear();
                    MainPanel.Visible = true;
                    cbInterval.Enabled = false;
                    lblCancelCustom.Visible = true;
                }
            }
            else
            {
                txtMinReps.Clear();
                txtMaxReps.Clear();
                MainPanel.Visible = false;
            }
        }

        private void lblCancelCustom_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtMinReps.Clear();
            txtMaxReps.Clear();
            MainPanel.Visible = false;
            cbInterval.Enabled = true;
            lblCancelCustom.Visible = false;
            cbInterval.SelectedValue = currentIntervalId;
        }
    }
}
