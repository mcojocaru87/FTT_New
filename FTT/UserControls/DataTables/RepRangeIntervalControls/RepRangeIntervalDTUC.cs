using FTT.DataAccesss;
using FTT.DbEntity;
using Microsoft.Extensions.DependencyInjection;

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
            DataGridView dataGridView = (DataGridView)sender;
            if (dataGridView?.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView.SelectedRows[0];

                // Display or process the selected data
                if (selectedRow.DataBoundItem is RepRangeInterval selectedRepRangeInterval)
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
    }
}
