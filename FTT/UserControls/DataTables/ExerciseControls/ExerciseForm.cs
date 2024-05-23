using FTT.DataAccesss;
using FTT.DbEntity;
using FTT.ViewModels;

namespace FTT.UserControls.DataTables.ExerciseControls
{
    public partial class ExerciseForm : Form
    {
        private readonly IRepository<Exercise> _exerciseRepository;
        private readonly int _exerciseId;

        private Exercise _exercise;
        public ExerciseForm(IRepository<Exercise> exerciseRepository, int exerciseId)
        {
            InitializeComponent();

            _exerciseRepository = exerciseRepository;
            _exerciseId = exerciseId;

            LoadMultiplierData();
            LoadData();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void LoadData()
        {
            if (_exerciseId > 0)
            {
                var exercise = _exerciseRepository.GetById(_exerciseId);

                if (exercise != null)
                {
                    txtId.Text = exercise.Id.ToString();
                    txtName.Text = exercise.Name;
                    cbMultiplier.SelectedValue = exercise.Multiplier;

                    _exercise = exercise;
                }
            }
        }

        private void LoadMultiplierData()
        {
            List<ComboBoxViewModel> multiplierData = [
                new(1, "x1"),
                new(2, "x2")
            ];

            cbMultiplier.DataSource = multiplierData;

            cbMultiplier.ValueMember = "ValueMember";
            cbMultiplier.DisplayMember = "DisplayMember";
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (_exerciseId > 0)
            {
                _exercise.Multiplier = (int)cbMultiplier.SelectedValue;
                _exercise.Name = txtName.Text;

                _exerciseRepository.Update(_exercise);
                _exerciseRepository.Commit();

                MessageBox.Show($"Exercise has been successfully updated!", "Success", MessageBoxButtons.OK);
            }
            else
            {
                var newExercise = new Exercise { Name = txtName.Text, Multiplier = (int)cbMultiplier.SelectedValue };

                _exerciseRepository.Add(newExercise);
                _exerciseRepository.Commit();

                MessageBox.Show($"Exercise has been successfully created! Id: {newExercise.Id}", "Success", MessageBoxButtons.OK);
            }

            this.Dispose();
            this.Close();
        }
    }
}
