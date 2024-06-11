using FTT.DataAccesss;
using FTT.DbEntity;
using FTT.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace FTT
{
    public partial class CalculatorForm : Form
    {
        private readonly ServiceProvider serviceProvider = Session.Instance.ServiceProvider;

        private readonly IRepository<Exercise> _exerciseRepository;
        private readonly IRepository<Setting> _exerciseSettingsRepository;

        private int selectedExerciseId = 0;
        private Setting selectedExerciseSettings = null!;

        public CalculatorForm()
        {
            InitializeComponent();

            _exerciseRepository = serviceProvider.GetRequiredService<IRepository<Exercise>>();
            _exerciseSettingsRepository = serviceProvider.GetRequiredService<IRepository<Setting>>();

            LoadExerciseData();
        }

        private void ResetForm()
        {
            selectedExerciseId = 0;
            selectedExerciseSettings = null!;
        }

        private void LoadExerciseData()
        {
            var exercises = _exerciseRepository.GetAll()
                .Select(x => new ComboBoxViewModel(x.Id, x.Name))
                .ToList();

            if (exercises.Count > 0)
            {
                cbExercises.DataSource = exercises;
                cbExercises.DisplayMember = "DisplayMember";
                cbExercises.ValueMember = "ValueMember";

                cbExercises.SelectedIndex = 0;
            }
        }

        private void LoadExerciseSettings(int exerciseId)
        {
            var exerciseSettings = _exerciseSettingsRepository
                .Find(x => x.ExerciseId == exerciseId)
                .FirstOrDefault();

            if (exerciseSettings != null)
            {
                selectedExerciseSettings = exerciseSettings;
            }
        }

        private void cbExercises_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbExercises.SelectedItem is ComboBoxViewModel selectedExercise && selectedExercise.ValueMember != null)
            {
                selectedExerciseId = (int)selectedExercise.ValueMember;

                LoadExerciseSettings(selectedExerciseId);
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            ResetForm();

            this.Dispose();
            this.Close();
        }
    }
}
