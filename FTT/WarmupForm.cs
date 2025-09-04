using FTT.DataAccesss;
using FTT.DbEntity;
using FTT.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTT
{
    public partial class WarmupForm : Form
    {
        private readonly IRepository<Exercise> _exerciseRepository;
        private readonly IRepository<Equipment> _equipmentRepository;
        private Exercise _exercise;
        private IList<decimal> _equipmentWeights;

        public WarmupForm(int exerciseId, decimal workingWeight)
        {
            InitializeComponent();
            SetWarmupPercentageDefaults();

            _equipmentWeights = [];

            _exerciseRepository = Session.Instance.ServiceProvider.GetRequiredService<IRepository<Exercise>>();
            _equipmentRepository = Session.Instance.ServiceProvider.GetRequiredService<IRepository<Equipment>>();

            LoadExerciseData(exerciseId);
            LoadEquipmentItems(_exercise!.EquipmentId);

            SetWorkingWeight(workingWeight);

            CalculateWarmupSets();
        }

        private void SetWorkingWeight(decimal workingWeight)
        {
            cbWeight.SelectedValue = workingWeight;
        }

        private void SetWarmupPercentageDefaults()
        {
            txtWarmupSet1.Text = "30";
            txtWarmupSet2.Text = "50";
            txtWarmupSet3.Text = "70";
        }

        private void LoadExerciseData(int exerciseId)
        {
            var exercise = _exerciseRepository.GetById(exerciseId);

            if (exercise != null)
            {
                _exercise = exercise;
                lblExerciseName.Text = exercise.Name;
            }
        }

        private void LoadEquipmentItems(int equipmentId)
        {
            cbWeight.DataSource = null;

            var equipment = _equipmentRepository
                .GetById(equipmentId, true, "Items");

            if (equipment != null &&
                equipment.Items != null &&
                equipment.Items.Count > 0)
            {
                var dataSource = equipment.Items
                    .Select(x => new ComboBoxViewModel(x.Weight, x.Weight.ToString()))
                    .ToList();

                dataSource.Add(new(0M, 0.ToString()));

                dataSource = [.. dataSource.OrderBy(x => x.ValueMember)];

                _equipmentWeights = [.. dataSource.Select(x => (decimal)x.ValueMember!)];

                cbWeight.DataSource = dataSource;
                cbWeight.DisplayMember = "DisplayMember";
                cbWeight.ValueMember = "ValueMember";
                cbWeight.Visible = true;
            }
            else
            {
                cbWeight.Visible = false;
            }
        }

        private void CalculateWarmupSets()
        {
            if (decimal.TryParse(cbWeight.SelectedValue?.ToString(), out decimal workingWeight) &&
                decimal.TryParse(txtWarmupSet1.Text, out decimal warmupSet1Percentage) &&
                decimal.TryParse(txtWarmupSet2.Text, out decimal warmupSet2Percentage) &&
                decimal.TryParse(txtWarmupSet3.Text, out decimal warmupSet3Percentage))
            {
                lblWarmupWeight1.Text = FindClosestWeight(Math.Round((workingWeight * (warmupSet1Percentage / 100)), 2)).ToString();
                lblWarmupWeight2.Text = FindClosestWeight(Math.Round((workingWeight * (warmupSet2Percentage / 100)), 2)).ToString();
                lblWarmupWeight3.Text = FindClosestWeight(Math.Round((workingWeight * (warmupSet3Percentage / 100)), 2)).ToString();
            }
        }

        private decimal FindClosestWeight(decimal targetWeight)
        {
            if (_equipmentWeights == null || _equipmentWeights.Count == 0)
            {
                return targetWeight;
            }
            decimal closest = _equipmentWeights[0];
            decimal smallestDifference = Math.Abs(targetWeight - closest);
            foreach (var weight in _equipmentWeights)
            {
                decimal difference = Math.Abs(targetWeight - weight);
                if (difference < smallestDifference)
                {
                    smallestDifference = difference;
                    closest = weight;
                }
            }
            return closest;
        }

        private void cbWeight_SelectedValueChanged(object sender, EventArgs e)
        {
            CalculateWarmupSets();
        }
    }
}
