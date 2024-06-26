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
        private int multiplier = 1;
        private decimal calculatedMinAVolume = 0;
        private decimal calculatedMinBVolume = 0;
        private decimal calculatedTotalMinAVolume = 0;
        private decimal calculatedTotalMinBVolume = 0;
        private decimal calculatedMaxAVolume = 0;
        private decimal calculatedMaxBVolume = 0;
        private decimal calculatedTotalMaxAVolume = 0;
        private decimal calculatedTotalMaxBVolume = 0;
        private decimal minCalculatedWeight = 0;
        private decimal maxCalculatedWeight = 0;

        public CalculatorForm()
        {
            InitializeComponent();

            _exerciseRepository = serviceProvider.GetRequiredService<IRepository<Exercise>>();
            _exerciseSettingsRepository = serviceProvider.GetRequiredService<IRepository<Setting>>();
            _intervalRepository = serviceProvider.GetRequiredService<IRepository<RepRangeInterval>>();
            _equipmentRepository = serviceProvider.GetRequiredService<IRepository<Equipment>>();
            _equipmentItemRepository = serviceProvider.GetRequiredService<IRepository<EquipmentItem>>();

            LoadSetsData();
            LoadExerciseData();
        }

        private void ResetForm()
        {
            selectedExerciseId = 0;
            selectedExerciseEquipmentId = 0;
            selectedExerciseSettings = null!;
            multiplier = 1;
            calculatedMinAVolume = 0;
            calculatedMinBVolume = 0;
            calculatedTotalMinAVolume = 0;
            calculatedTotalMinBVolume = 0;
            calculatedMaxAVolume = 0;
            calculatedMaxBVolume = 0;
            calculatedTotalMaxAVolume = 0;
            calculatedTotalMaxBVolume = 0;

            if (cbNewIntervals.SelectedIndex >= 0)
                cbNewIntervals.SelectedIndex = 0;
            if (cbNewSets.SelectedIndex >= 0)
                cbNewSets.SelectedIndex = 0;
            if (cbDefaultIntervals.SelectedIndex >= 0)
                cbDefaultIntervals.SelectedIndex = 0;
            if (cbDefaultSets.SelectedIndex >= 0)
                cbDefaultSets.SelectedIndex = 0;
            if (cbWeight.SelectedIndex >= 0)
                cbWeight.SelectedIndex = 0;
            if (cbMinWeight.SelectedIndex >= 0)
                cbMinWeight.SelectedIndex = 0;
            if (cbMaxWeight.SelectedIndex >= 0)
                cbMaxWeight.SelectedIndex = 0;
        }

        private void LoadExerciseWeight(int equipmentId, ComboBox control)
        {
            List<ComboBoxViewModel> dataSource = [];

            var equipment = _equipmentRepository
                .GetById(equipmentId, true, "Items");

            if (equipment != null)
            {
                if (equipment.Items.Count > 0)
                {
                    foreach (var item in equipment.Items)
                    {
                        dataSource.Add(new ComboBoxViewModel(item.Weight, item.Weight.ToString()));
                    }

                    dataSource.Add(new ComboBoxViewModel(0M, "0"));
                    dataSource = dataSource.OrderBy(x => (decimal)x.ValueMember!).ToList();
                }

                if (dataSource.Count > 0)
                {
                    control.DataSource = dataSource;
                    control.DisplayMember = "DisplayMember";
                    control.ValueMember = "ValueMember";
                    control.SelectedIndex = 0;
                }
            }
        }

        private void LoadSetsData()
        {
            List<ComboBoxViewModel> defaultDataSource = new();
            List<ComboBoxViewModel> dataSource = new();

            for (int i = 1; i <= 6; i++)
            {
                defaultDataSource.Add(new(i, i.ToString()));
                dataSource.Add(new(i, i.ToString()));
            }

            cbDefaultSets.DataSource = defaultDataSource;
            cbDefaultSets.DisplayMember = "DisplayMember";
            cbDefaultSets.ValueMember = "ValueMember";
            cbDefaultSets.SelectedValue = 1;

            cbNewSets.DataSource = dataSource;
            cbNewSets.DisplayMember = "DisplayMember";
            cbNewSets.ValueMember = "ValueMember";
            cbNewSets.SelectedValue = 1;
        }

        private decimal[] LoadEquipmentItemWeights(int equipmentId)
        {
            return [.. _equipmentItemRepository
                .Find(x => x.EquipmentId == equipmentId)
                .Select(x => x.Weight)];
        }

        private void LoadIntervalData(int exerciseIntervalId)
        {
            var defaultIntervals = _intervalRepository.GetAll()
                .Select(x => new ComboBoxViewModel(x.Id, $"{x.MinReps} - {x.MaxReps}"))
                .ToList();

            var newIntervals = _intervalRepository.GetAll()
                .Select(x => new ComboBoxViewModel(x.Id, $"{x.MinReps} - {x.MaxReps}"))
                .ToList();

            if (defaultIntervals.Count > 0)
            {
                cbDefaultIntervals.DataSource = defaultIntervals;
                cbDefaultIntervals.DisplayMember = "DisplayMember";
                cbDefaultIntervals.ValueMember = "ValueMember";
                cbDefaultIntervals.SelectedValue = exerciseIntervalId;
            }

            if (newIntervals.Count > 0)
            {
                cbNewIntervals.DataSource = newIntervals;
                cbNewIntervals.DisplayMember = "DisplayMember";
                cbNewIntervals.ValueMember = "ValueMember";
                if (cbNewIntervals.SelectedIndex >= 0)
                    cbNewIntervals.SelectedIndex = 0;
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

                lblDefaultRange.Text = $"{minReps} - {maxReps}";
                cbDefaultSets.SelectedValue = exerciseSettings.MinSets;
                cbDefaultIntervals.SelectedValue = intervalId;

                var equipment = GetEquipment(exercise.EquipmentId);

                if (equipment != null)
                {
                    selectedExerciseEquipmentId = equipment.Id;

                    lblEquipmentUsed.Text = equipment.Name;

                    var weight = (decimal?)cbWeight.SelectedValue ?? 0;

                    if (weight > 0)
                    {
                        lblDefaultVolume.Text = $"{weight * minReps * multiplier} - {weight * maxReps * multiplier} Kg";
                        lblDefaultTotalVolume.Text = $"{weight * minReps * multiplier * (int)cbDefaultSets.SelectedValue} - {weight * maxReps * multiplier * (int)cbDefaultSets.SelectedValue} Kg";
                        lblCalculatedMinVolume.Text = "N/A";
                        lblCalculatedTotalMinVolume.Text = "N/A";
                        cbMinWeight.SelectedIndex = 0;
                        cbMaxWeight.SelectedIndex = 0;
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
                    multiplier = exercise.Multiplier;

                    LoadExerciseWeight(exercise.EquipmentId, cbWeight);
                    LoadExerciseWeight(exercise.EquipmentId, cbMinWeight);
                    LoadExerciseWeight(exercise.EquipmentId, cbMaxWeight);
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
            var weight = (decimal?)cbWeight.SelectedValue ?? 0;

            if (weight == 0)
            {
                return;
            }

            var defaultIntervalId = (int?)cbDefaultIntervals.SelectedValue ?? 1;
            var newIntervalId = (int?)cbNewIntervals.SelectedValue ?? 1;

            var defaultInterval = GetInterval(defaultIntervalId);
            var newInterval = GetInterval(newIntervalId);

            if (defaultInterval != null && newInterval != null)
            {
                var defaultMinReps = defaultInterval.MinReps;
                var defaultMaxReps = defaultInterval.MaxReps;

                var newMinReps = newInterval.MinReps;
                var newMaxReps = newInterval.MaxReps;

                if (selectedExerciseEquipmentId == 0)
                {
                    return;
                }

                var range = LoadEquipmentItemWeights(selectedExerciseEquipmentId);

                var minWeight = (weight * defaultMinReps * (int?)cbDefaultSets.SelectedValue ?? 1) / newMinReps / (int?)cbNewSets.SelectedValue ?? 1;
                var maxWeight = (weight * defaultMaxReps * (int?)cbDefaultSets.SelectedValue ?? 1) / newMaxReps / (int?)cbNewSets.SelectedValue ?? 1;

                if (minWeight > 0 && maxWeight > 0)
                {
                    var calculatedMinWeight = GetClosest(minWeight, range);
                    var calculatedMaxWeight = GetClosest(maxWeight, range);

                    if (calculatedMinWeight > 0 && calculatedMaxWeight > 0)
                    {
                        calculatedMinAVolume = calculatedMinWeight * newMinReps * multiplier;
                        calculatedMinBVolume = calculatedMinWeight * newMaxReps * multiplier;
                        
                        calculatedMaxAVolume = calculatedMaxWeight * newMinReps * multiplier;
                        calculatedMaxBVolume = calculatedMaxWeight * newMaxReps * multiplier;

                        lblCalculatedMinVolume.Text = $"{calculatedMinAVolume} - {calculatedMinBVolume} Kg";
                        lblCalculatedMaxVolume.Text = $"{calculatedMaxAVolume} - {calculatedMaxBVolume} Kg";

                        calculatedTotalMinAVolume = calculatedMinWeight * newMinReps * multiplier * (int?)cbNewSets.SelectedValue ?? 1;
                        calculatedTotalMinBVolume = calculatedMinWeight * newMaxReps * multiplier * (int?)cbNewSets.SelectedValue ?? 1;
                        
                        calculatedTotalMaxAVolume = calculatedMaxWeight * newMinReps * multiplier * (int?)cbNewSets.SelectedValue ?? 1;
                        calculatedTotalMaxBVolume = calculatedMaxWeight * newMaxReps * multiplier * (int?)cbNewSets.SelectedValue ?? 1;

                        lblCalculatedTotalMinVolume.Text = $"{calculatedTotalMinAVolume} - {calculatedTotalMinBVolume} Kg";
                        lblCalculatedTotalMaxVolume.Text = $"{calculatedTotalMaxAVolume} - {calculatedTotalMaxBVolume} Kg";

                        minCalculatedWeight = calculatedMinWeight;
                        maxCalculatedWeight = calculatedMaxWeight;

                        cbMinWeight.SelectedValue = calculatedMinWeight;
                        cbMaxWeight.SelectedValue = calculatedMaxWeight;
                    }
                    else
                    {
                        lblCalculatedMinVolume.Text = "N/A";
                        lblCalculatedTotalMinVolume.Text = "N/A";
                        cbMinWeight.SelectedIndex = 0;
                        cbMaxWeight.SelectedIndex = 0;
                    }
                }
            }
        }

        private void cbDefaultSets_SelectedIndexChanged(object sender, EventArgs e)
        {
            var weight = (decimal?)cbWeight.SelectedValue ?? 0;
            var sets = 1;

            if (weight == 0)
            {
                return;
            }

            if (cbDefaultSets.SelectedItem is ComboBoxViewModel selectedDefaultSets && selectedDefaultSets.ValueMember != null)
            {
                sets = (int)selectedDefaultSets.ValueMember;
            }

            var defaultIntervalId = (int?)cbDefaultIntervals.SelectedValue ?? 1;

            var interval = GetInterval(defaultIntervalId);

            if (interval != null)
            {
                lblDefaultVolume.Text = $"{weight * interval.MinReps * multiplier} - {weight * interval.MaxReps * multiplier} Kg";
                lblDefaultTotalVolume.Text = $"{weight * interval.MinReps * multiplier * sets} - {weight * interval.MaxReps * multiplier * sets} Kg";
            }
        }

        private void cbDefaultIntervals_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDefaultIntervals.SelectedItem is ComboBoxViewModel selectedInterval && selectedInterval.ValueMember != null)
            {
                lblDefaultRange.Text = selectedInterval.DisplayMember;

                cbDefaultSets_SelectedIndexChanged(this, null!);
                CalculateButton_Click(this, null!);
            }
        }

        private void cbWeight_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbWeight.SelectedItem is ComboBoxViewModel selectedWeight && selectedWeight.ValueMember != null)
            {
                var weight = (decimal)selectedWeight.ValueMember;

                if (weight == 0)
                {
                    return;
                }

                var defaultIntervalId = (int?)cbDefaultIntervals.SelectedValue ?? 1;

                var interval = GetInterval(defaultIntervalId);

                if (interval != null)
                {
                    lblDefaultVolume.Text = $"{weight * interval.MinReps * multiplier} - {weight * interval.MaxReps * multiplier} Kg";
                    lblDefaultTotalVolume.Text = $"{weight * interval.MinReps * multiplier * (int?)cbDefaultSets.SelectedValue ?? 1} - {weight * interval.MaxReps * multiplier * (int?)cbDefaultSets.SelectedValue ?? 1} Kg";
                }
            }
        }

        private void cbMinWeight_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMinWeight.SelectedItem is ComboBoxViewModel selectedMinWeight && selectedMinWeight.ValueMember != null)
            {
                //if (minCalculatedWeight > 0 &&
                //    calculatedMinVolume > 0 &&
                //    calculatedMaxVolume > 0)
                //{
                //    var minVolume = calculatedMinVolume / minCalculatedWeight * (decimal)selectedMinWeight.ValueMember;
                //    var maxVolume = calculatedMaxVolume / minCalculatedWeight * (decimal)selectedMinWeight.ValueMember;

                //    lblCalculatedMinVolume.Text = $"{minVolume:0.00} - {maxVolume:0.00} Kg";
                //}
            }
        }

        private void cbMaxWeight_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMaxWeight.SelectedItem is ComboBoxViewModel selectedMaxWeight && selectedMaxWeight.ValueMember != null)
            {
                //if (maxCalculatedWeight > 0 &&
                //    calculatedTotalMinVolume > 0 &&
                //    calculatedTotalMaxVolume > 0)
                //{
                //    var minVolume = calculatedTotalMinVolume / maxCalculatedWeight * (decimal)selectedMaxWeight.ValueMember;
                //    var maxVolume = calculatedTotalMaxVolume / maxCalculatedWeight * (decimal)selectedMaxWeight.ValueMember;

                //    lblCalculatedTotalMinVolume.Text = $"{minVolume:0.00} - {maxVolume:0.00} Kg";
                //}
            }
        }
    }
}
