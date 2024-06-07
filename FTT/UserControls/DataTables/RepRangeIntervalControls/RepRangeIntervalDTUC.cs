using FTT.DataAccesss;
using FTT.DbEntity;
using FTT.UserControls.DataTables.ToolTimerControls;
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

namespace FTT.UserControls.DataTables.RepRangeIntervalControls
{
    public partial class RepRangeIntervalDTUC : UserControl
    {
        private readonly IRepository<RepRangeInterval> _repRangeIntervalRepository;
        private readonly IRepository<Exercise> _exerciseRepository;

        private int selectedRepRangeIntervalId = 0;

        public RepRangeIntervalDTUC()
        {
            InitializeComponent();

            _repRangeIntervalRepository = Session.Instance.ServiceProvider.GetRequiredService<IRepository<RepRangeInterval>>();
            _exerciseRepository = Session.Instance.ServiceProvider.GetRequiredService<IRepository<Exercise>>();

            EnableEditRemoveButtons(false, false);
            LoadData();
            CustomizeDataGridView();
        }

        private void LoadData()
        {
            List<RepRangeInterval> repRangeIntervals = [.. _repRangeIntervalRepository.GetAll()];

            foreach (var item in repRangeIntervals)
            {
                item.ExerciseName = ExerciseName(item.ExerciseId);
            }

            dgvExercise.DataSource = repRangeIntervals;
        }

        private void CustomizeDataGridView()
        {
            dgvExercise.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void EnableEditRemoveButtons(bool isEdit, bool isRemove)
        {
            EditButton.Enabled = isEdit;
            RemoveButton.Enabled = isRemove;
        }

        private void AddNewButton_Click(object sender, EventArgs e)
        {
            RepRangeIntervalForm repRangeIntervalForm = new(0);

            repRangeIntervalForm.ShowDialog();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            RepRangeIntervalForm repRangeIntervalForm = new(selectedRepRangeIntervalId);

            repRangeIntervalForm.ShowDialog();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            dgvExercise.DataSource = null;

            LoadData();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            var messageResponse = MessageBox.Show("Are you sure you want to remove this interval?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (messageResponse == DialogResult.OK)
            {
                var repRangeInterval = _repRangeIntervalRepository.GetById(selectedRepRangeIntervalId);

                if (repRangeInterval != null)
                {
                    _repRangeIntervalRepository.Delete(repRangeInterval);
                    _repRangeIntervalRepository.Commit();

                    LoadData();
                }
                else
                {
                    MessageBox.Show("Interval was not found in database!");
                }
            }
        }

        private void dgvExercise_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dataGridView = sender as DataGridView;
            if (dataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
                RepRangeInterval selectedRepRangeInterval = selectedRow.DataBoundItem as RepRangeInterval;

                // Display or process the selected data
                if (selectedRepRangeInterval != null)
                {
                    selectedRepRangeIntervalId = selectedRepRangeInterval.Id;

                    EnableEditRemoveButtons(true, true);
                }
            }
            else
            {
                EnableEditRemoveButtons(false, false);
            }
        }

        private string ExerciseName(int exerciseId)
        {
            string exerciseName = string.Empty;

            var exercise = _exerciseRepository.GetById(exerciseId);

            if (exercise != null)
            {
                exerciseName = exercise.Name;
            }

            return exerciseName;
        }
    }
}
