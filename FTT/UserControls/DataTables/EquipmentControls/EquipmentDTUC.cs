using FTT.DataAccesss;
using FTT.DbEntity;
using Microsoft.Extensions.DependencyInjection;

namespace FTT.UserControls.DataTables.EquipmentControls
{
    public partial class EquipmentDTUC : UserControl
    {
        private readonly IRepository<Equipment> _equipmentRepository;

        private int selectedEquipmentId = 0;

        public EquipmentDTUC()
        {
            InitializeComponent();

            _equipmentRepository = Session.Instance.ServiceProvider.GetRequiredService<IRepository<Equipment>>();

            EnableEditRemoveViewButtons(false, false, false);
            LoadData();
            CustomizeDataGridView();
        }

        private void AddNewButton_Click(object sender, EventArgs e)
        {
            EquipmentForm equipmentForm = new(0);

            equipmentForm.ShowDialog();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            EquipmentForm equipmentForm = new(selectedEquipmentId);

            equipmentForm.ShowDialog();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            dgvEquipment.DataSource = null;

            LoadData();
        }

        private void ViewDetailsButton_Click(object sender, EventArgs e)
        {
            EquipmentItemsViewForm viewForm = new(selectedEquipmentId);

            viewForm.ShowDialog();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            var messageResponse = MessageBox.Show("Are you sure you want to remove this equipment?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (messageResponse == DialogResult.OK)
            {
                var exercise = _equipmentRepository
                    .GetById(selectedEquipmentId, true, "Items");

                if (exercise != null)
                {
                    _equipmentRepository.Delete(exercise);
                    _equipmentRepository.Commit();

                    LoadData();
                }
                else
                {
                    MessageBox.Show("Exercise was not found in database!");
                }
            }
        }

        private void EnableEditRemoveViewButtons(bool isEdit, bool isRemove, bool isView)
        {
            EditButton.Enabled = isEdit;
            RemoveButton.Enabled = isRemove;
            ViewDetailsButton.Enabled = isView;
        }

        private void CustomizeDataGridView()
        {
            dgvEquipment.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadData()
        {
            List<Equipment> equipments = [.. _equipmentRepository.GetAll()];

            dgvEquipment.DataSource = equipments;
        }

        private void dgvEquipment_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dataGridView = sender as DataGridView;
            if (dataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView.SelectedRows[0];

                // Display or process the selected data
                if (selectedRow.DataBoundItem is Equipment selectedEquipment)
                {
                    selectedEquipmentId = selectedEquipment.Id;

                    EnableEditRemoveViewButtons(true, true, true);
                }
            }
            else
            {
                EnableEditRemoveViewButtons(false, false, false);
            }
        }
    }
}
