using FTT.DataAccesss;
using FTT.DbEntity;
using FTT.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace FTT.UserControls.DataTables.RepRangeIntervalControls
{
    public partial class RepRangeIntervalForm : Form
    {
        private readonly IRepository<RepRangeInterval> _repRangeIntervalRepository;
        private readonly IRepository<Exercise> _exerciseRepository;
        private readonly int _repRangeIntervalId = 0;

        private RepRangeInterval _repRangeInterval = null!;

        public RepRangeIntervalForm(int repRangeIntervalId)
        {
            InitializeComponent();

            _repRangeIntervalRepository = Session.Instance.ServiceProvider.GetRequiredService<IRepository<RepRangeInterval>>();
            _exerciseRepository = Session.Instance.ServiceProvider.GetRequiredService<IRepository<Exercise>>();
            _repRangeIntervalId = repRangeIntervalId;

            LoadIsSelectedData();
            LoadExerciseData();
            LoadData();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (_repRangeIntervalId > 0)
            {
                _repRangeInterval.ExerciseId = (int)cbExercises.SelectedValue;
                _repRangeInterval.MinReps = int.Parse(txtMinReps.Text);
                _repRangeInterval.MaxReps = int.Parse(txtMaxReps.Text);
                _repRangeInterval.IsSelected = (int)cbIsSelected.SelectedValue == 1;

                if (_repRangeInterval.IsSelected)
                {
                    UnselectAllIntervalsForExercise(_repRangeInterval.ExerciseId);
                }

                _repRangeIntervalRepository.Update(_repRangeInterval);
                _repRangeIntervalRepository.Commit();

                MessageBox.Show($"Interval has been successfully updated!", "Success", MessageBoxButtons.OK);
            }
            else
            {
                var newRepRangeInterval = new RepRangeInterval
                {
                    ExerciseId = (int)cbExercises.SelectedValue,
                    MinReps = int.Parse(txtMinReps.Text),
                    MaxReps = int.Parse(txtMaxReps.Text),
                    IsSelected = (int)cbIsSelected.SelectedValue == 1
                };

                if (newRepRangeInterval.IsSelected)
                {
                    UnselectAllIntervalsForExercise(newRepRangeInterval.ExerciseId);
                }

                _repRangeIntervalRepository.Add(newRepRangeInterval);
                _repRangeIntervalRepository.Commit();

                MessageBox.Show($"Timer has been successfully created! Id: {newRepRangeInterval.Id}", "Success", MessageBoxButtons.OK);
            }

            this.Dispose();
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void LoadExerciseData()
        {
            var exercises = _exerciseRepository.GetAll()
                .Select(x => new ComboBoxViewModel(x.Id, x.Name))
                .ToList();

            cbExercises.DataSource = exercises;

            cbExercises.ValueMember = "ValueMember";
            cbExercises.DisplayMember = "DisplayMember";
        }

        private void LoadIsSelectedData()
        {
            List<ComboBoxViewModel> displayData = [
                    new(0, "No"),
                    new(1, "Yes")
               ];

            cbIsSelected.DataSource = displayData;

            cbIsSelected.ValueMember = "ValueMember";
            cbIsSelected.DisplayMember = "DisplayMember";
        }

        private void LoadData()
        {
            if (_repRangeIntervalId > 0)
            {
                var repRangeInterval = _repRangeIntervalRepository.GetById(_repRangeIntervalId);

                if (repRangeInterval != null)
                {
                    txtId.Text = repRangeInterval.Id.ToString();
                    cbExercises.SelectedValue = repRangeInterval.ExerciseId;
                    txtMinReps.Text = repRangeInterval.MinReps.ToString();
                    txtMaxReps.Text = repRangeInterval.MaxReps.ToString();
                    cbIsSelected.SelectedValue = repRangeInterval.IsSelected ? 1 : 0;

                    _repRangeInterval = repRangeInterval;
                }
            }
        }

        private void UnselectAllIntervalsForExercise(int exerciseId)
        {
            var exerciseIntervals = _repRangeIntervalRepository
                .Find(x => x.ExerciseId == exerciseId && x.IsSelected == true)
                .ToList();

            if (exerciseIntervals.Count > 0)
            {
                foreach (var item in exerciseIntervals)
                {
                    item.IsSelected = false;

                    _repRangeIntervalRepository.Update(item);
                }

                _repRangeIntervalRepository.Commit();
            }
        }
    }
}
