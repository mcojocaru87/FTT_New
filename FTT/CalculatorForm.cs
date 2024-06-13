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
        private readonly IRepository<RepRangeInterval> _intervalRepository;
        private readonly IRepository<Setting> _exerciseSettingsRepository;
        private readonly IRepository<Equipment> _equipmentRepository;
        private readonly IRepository<EquipmentItem> _equipmentItemRepository;

        private int selectedExerciseId = 0;
        private Setting selectedExerciseSettings = null!;
        private int selectedExerciseEquipmentId = 0;
        private int selectedMinReps = 0;
        private int selectedMaxReps = 0;
        private int defaultMinReps = 0;
        private int defaultMaxReps = 0;

        public CalculatorForm()
        {
            InitializeComponent();

            _exerciseRepository = serviceProvider.GetRequiredService<IRepository<Exercise>>();
            _exerciseSettingsRepository = serviceProvider.GetRequiredService<IRepository<Setting>>();
            _intervalRepository = serviceProvider.GetRequiredService<IRepository<RepRangeInterval>>();
            _equipmentRepository = serviceProvider.GetRequiredService<IRepository<Equipment>>();
            _equipmentItemRepository = serviceProvider.GetRequiredService<IRepository<EquipmentItem>>();

            txtWeight.Text = 0.ToString();

            LoadExerciseData();
        }

        private void ResetForm()
        {
            selectedExerciseId = 0;
            selectedExerciseEquipmentId = 0;
            selectedExerciseSettings = null!;
            selectedMinReps = 0;
            selectedMaxReps = 0;
            defaultMinReps = 0;
            defaultMaxReps = 0;
        }

        private decimal[] LoadEquipmentItemWeights(int equipmentId)
        {
            return [.. _equipmentItemRepository
                .Find(x => x.EquipmentId == equipmentId)
                .Select(x => x.Weight)];
        }

        private void LoadIntervalData(int exerciseIntervalId)
        {
            var intervals = _intervalRepository.GetAll()
                .Select(x => new ComboBoxViewModel(x.Id, $"{x.MinReps} - {x.MaxReps}"))
                .ToList();

            if (intervals.Count > 0)
            {
                cbIntervals.DataSource = intervals;
                cbIntervals.DisplayMember = "DisplayMember";
                cbIntervals.ValueMember = "ValueMember";

                cbIntervals.SelectedValue = exerciseIntervalId;
            }
        }

        private Exercise GetExercise(int exerciseId)
        {
            return _exerciseRepository.GetById(exerciseId);
        }

        private Equipment GetEquipment(int equipmentId)
        {
            return _equipmentRepository.GetById(equipmentId);
        }

        private RepRangeInterval GetInterval(int intervalId)
        {
            return _intervalRepository.GetById(intervalId);
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

        private void LoadExerciseSettings(Exercise exercise)
        {
            var intervalId = 0;

            var exerciseSettings = _exerciseSettingsRepository
                .Find(x => x.ExerciseId == exercise.Id)
                .FirstOrDefault();

            if (exerciseSettings != null)
            {
                selectedExerciseSettings = exerciseSettings;
                intervalId = selectedExerciseSettings.RepRangeIntervalId;

                var minReps = exerciseSettings.MinReps;
                var maxReps = exerciseSettings.MaxReps;

                selectedMinReps = minReps;
                selectedMaxReps = maxReps;

                defaultMinReps = minReps;
                defaultMaxReps = maxReps;

                lblDefaultRange.Text = $"{minReps} - {maxReps}";

                var equipment = GetEquipment(exercise.EquipmentId);

                if (equipment != null)
                {
                    selectedExerciseEquipmentId = equipment.Id;

                    lblEquipmentUsed.Text = equipment.Name;

                    var isValidWeight = decimal.TryParse(txtWeight.Text, out decimal weight);

                    if (isValidWeight)
                    {
                        lblDefaultVolume.Text = $"{weight * minReps} - {weight * maxReps} Kg";
                        lblCalculatedVolume.Text = "N/A";
                        lblMinWeight.Text = "N/A";
                        lblMaxWeight.Text = "N/A";
                    }

                    MainPanel.Visible = true;
                }
            }

            LoadIntervalData(intervalId);
        }

        private void cbExercises_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetForm();

            if (cbExercises.SelectedItem is ComboBoxViewModel selectedExercise && selectedExercise.ValueMember != null)
            {
                selectedExerciseId = (int)selectedExercise.ValueMember;

                var exercise = GetExercise(selectedExerciseId);

                if (exercise != null)
                {
                    LoadExerciseSettings(exercise);
                }
            }
            else
            {
                MainPanel.Visible = false;
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            ResetForm();

            this.Dispose();
            this.Close();
        }

        private decimal GetClosest(decimal weight, decimal[] range)
        {
            decimal closest = range.Min(x => x);
            decimal smallestDifference = Math.Abs(weight - closest);

            foreach (decimal value in range)
            {
                decimal currentDifference = Math.Abs(weight - value);

                if (currentDifference < smallestDifference)
                {
                    smallestDifference = currentDifference;
                    closest = value;
                }
            }

            return closest;
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            var isValidInput = decimal.TryParse(txtWeight.Text.Trim(), out decimal weight);

            if (!isValidInput)
            {
                weight = 0;
            }

            var range = LoadEquipmentItemWeights(selectedExerciseEquipmentId);

            var minWeight = (weight * defaultMinReps) / selectedMinReps;
            var maxWeight = (weight * defaultMaxReps) / selectedMaxReps;

            if (minWeight > 0 && maxWeight > 0)
            {
                var calculatedMinWeight = GetClosest(minWeight, range);
                var calculatedMaxWeight = GetClosest(maxWeight, range);

                if (calculatedMinWeight > 0 && calculatedMaxWeight > 0)
                {
                    lblCalculatedVolume.Text = $"{calculatedMinWeight * selectedMinReps} - {calculatedMaxWeight * selectedMaxReps} Kg";
                    lblMinWeight.Text = $"{calculatedMinWeight:0.00} Kg";
                    lblMaxWeight.Text = $"{calculatedMaxWeight:0.00} Kg";
                }
                else
                {
                    lblCalculatedVolume.Text = "N/A";
                    lblMinWeight.Text = "N/A";
                    lblMaxWeight.Text = "N/A";
                }
            }
        }

        private void cbIntervals_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbIntervals.SelectedItem is ComboBoxViewModel selectedInterval && selectedInterval.ValueMember != null)
            {
                var intervalId = (int)selectedInterval.ValueMember;

                var interval = GetInterval(intervalId);

                if (interval != null)
                {
                    selectedMinReps = interval.MinReps;
                    selectedMaxReps = interval.MaxReps;

                    CalculateButton_Click(this, null!);
                }
            }
        }

        private void txtWeight_TextChanged(object sender, EventArgs e)
        {
            var isValidInput = decimal.TryParse(txtWeight.Text.Trim(), out decimal weight);

            if (!isValidInput)
            {
                weight = 0;
            }

            lblDefaultVolume.Text = $"{weight * defaultMinReps} - {weight * defaultMaxReps} Kg";
        }
    }
}
