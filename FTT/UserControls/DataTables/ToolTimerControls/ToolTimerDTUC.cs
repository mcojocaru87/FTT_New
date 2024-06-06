using FTT.DataAccesss;
using FTT.DbEntity;
using FTT.UserControls.DataTables.ExerciseControls;
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

namespace FTT.UserControls.DataTables.ToolTimerControls
{
    public partial class ToolTimerDTUC : UserControl
    {
        private readonly IRepository<ToolTimer> _toolTimerRepository;

        private int toolTimerCount = 0;
        private int selectedToolTimerId = 0;

        public ToolTimerDTUC()
        {
            InitializeComponent();

            _toolTimerRepository = Session.Instance.ServiceProvider.GetRequiredService<IRepository<ToolTimer>>();

            EnableEditRemoveButtons(false, false);
            LoadData();
            CustomizeDataGridView();            
        }

        private void LoadData()
        {
            List<ToolTimer> toolTimers = [.. _toolTimerRepository.GetAll()];

            toolTimerCount = toolTimers.Count;

            EnableAddButton();

            dgvExercise.DataSource = toolTimers;
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

        private void EnableAddButton()
        {
            AddNewButton.Enabled = toolTimerCount == 0;
        }

        private void AddNewButton_Click(object sender, EventArgs e)
        {
            ToolTimerForm toolTimerForm = new(0);

            toolTimerForm.ShowDialog();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            ToolTimerForm toolTimerForm = new(selectedToolTimerId);

            toolTimerForm.ShowDialog();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            dgvExercise.DataSource = null;

            LoadData();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            var messageResponse = MessageBox.Show("Are you sure you want to remove this timer?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (messageResponse == DialogResult.OK)
            {
                var toolTimer = _toolTimerRepository.GetById(selectedToolTimerId);

                if (toolTimer != null)
                {
                    _toolTimerRepository.Delete(toolTimer);
                    _toolTimerRepository.Commit();

                    LoadData();
                }
                else
                {
                    MessageBox.Show("Timer was not found in database!");
                }
            }
        }

        private void dgvExercise_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dataGridView = sender as DataGridView;
            if (dataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
                ToolTimer selectedToolTimer = selectedRow.DataBoundItem as ToolTimer;

                // Display or process the selected data
                if (selectedToolTimer != null)
                {
                    selectedToolTimerId = selectedToolTimer.Id;

                    EnableEditRemoveButtons(true, true);
                }
            }
            else
            {
                EnableEditRemoveButtons(false, false);
            }
        }
    }
}
