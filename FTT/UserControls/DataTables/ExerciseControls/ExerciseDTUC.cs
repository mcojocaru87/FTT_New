using FTT.DataAccesss;
using FTT.DbEntity;
using Microsoft.Extensions.DependencyInjection;

namespace FTT.UserControls.DataTables.ExerciseControls
{
    public partial class ExerciseDTUC : UserControl
    {
        private readonly IRepository<Exercise> _exerciseRepository;
        private readonly IRepository<Setting> _settingsRepository;

        private int _selectedExerciseId;

        public ExerciseDTUC()
        {
            InitializeComponent();

            _exerciseRepository = Session.Instance.ServiceProvider.GetRequiredService<IRepository<Exercise>>();
            _settingsRepository = Session.Instance.ServiceProvider.GetRequiredService<IRepository<Setting>>();

            EnableEditRemoveButtons(false, false);
            LoadData();
            CustomizeDataGridView();
        }

        private void LoadData()
        {
            List<Exercise> exercises = [.. _exerciseRepository.GetAll()];

            dgvExercise.DataSource = exercises;
        }

        private void CustomizeDataGridView()
        {
            dgvExercise.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dgvExercise_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dataGridView = sender as DataGridView;
            if (dataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
                Exercise selectedExercise = selectedRow.DataBoundItem as Exercise;

                // Display or process the selected data
                if (selectedExercise != null)
                {
                    _selectedExerciseId = selectedExercise.Id;

                    EnableEditRemoveButtons(true, true);
                }
            }
            else
            {
                EnableEditRemoveButtons(false, false);
            }
        }

        private void EnableEditRemoveButtons(bool isEdit, bool isRemove)
        {
            EditButton.Enabled = isEdit;
            RemoveButton.Enabled = isRemove;
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            dgvExercise.DataSource = null;

            LoadData();
        }

        private void AddNewButton_Click(object sender, EventArgs e)
        {
            ExerciseForm exerciseForm = new(0);

            exerciseForm.ShowDialog();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            ExerciseForm exerciseForm = new(_selectedExerciseId);

            exerciseForm.ShowDialog();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            var messageResponse = MessageBox.Show("Are you sure you want to remove this exercise?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (messageResponse == DialogResult.OK)
            {
                var exercise = _exerciseRepository.GetById(_selectedExerciseId);
                var exerciseSettings = _settingsRepository
                    .Find(x => x.ExerciseId == _selectedExerciseId).FirstOrDefault();

                if (exercise != null)
                {
                    _exerciseRepository.Delete(exercise);
                    _exerciseRepository.Commit();

                    if (exerciseSettings != null)
                    {
                        _settingsRepository.Delete(exerciseSettings);
                        _settingsRepository.Commit();
                    }

                    LoadData();
                }
                else
                {
                    MessageBox.Show("Exercise was not found in database!");
                }
            }
        }
    }
}
