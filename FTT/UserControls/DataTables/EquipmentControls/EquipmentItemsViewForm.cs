using FTT.DataAccesss;
using FTT.DbEntity;
using FTT.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace FTT.UserControls.DataTables.EquipmentControls
{
    public partial class EquipmentItemsViewForm : Form
    {
        private readonly IRepository<Equipment> _equipmentRepository;
        private readonly IRepository<EquipmentItem> _equipmentItemRepository;
        private readonly int _equipmentId;

        private int selectedEquipmentItemId = 0;
        private EquipmentItem selectedEquipmentItem = null!;

        public EquipmentItemsViewForm(int equipmentId)
        {
            InitializeComponent();

            _equipmentRepository = Session.Instance.ServiceProvider.GetRequiredService<IRepository<Equipment>>();
            _equipmentItemRepository = Session.Instance.ServiceProvider.GetRequiredService<IRepository<EquipmentItem>>();
            _equipmentId = equipmentId;

            EnableEditRemoveButtons(false, false);
            LoadData();
            LoadEquipment();
            LoadUoM();
            LoadUnits();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void dgItems_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            if (dataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView.SelectedRows[0];

                // Display or process the selected data
                if (selectedRow.DataBoundItem is EquipmentItem selectedEquipmentItem)
                {
                    selectedEquipmentItemId = selectedEquipmentItem.Id;
                    this.selectedEquipmentItem = selectedEquipmentItem;

                    EnableEditRemoveButtons(true, true);
                    AddButton.Enabled = false;
                }
            }
            else
            {
                EnableEditRemoveButtons(false, false);
                AddButton.Enabled = true;
            }
        }

        private void EnableEditRemoveButtons(bool isEdit, bool isRemove)
        {
            EditButton.Enabled = isEdit;
            DeleteButton.Enabled = isRemove;
        }

        private void LoadData()
        {
            if (_equipmentId > 0)
            {
                var equipment = _equipmentRepository
                    .GetById(_equipmentId, true, "Items");

                if (equipment != null)
                {
                    txtSelectedEquipment.Text = equipment.Name;

                    var equipmentItems = equipment.Items.ToList();

                    if (equipmentItems.Count > 0)
                    {
                        dgItems.DataSource = equipmentItems;
                    }
                }
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            cbUnits.SelectedValue = 0;
            txtWeight.Clear();
            cbUoM.SelectedValue = 0;

            MainPanel.Visible = false;
            selectedEquipmentItemId = 0;
            selectedEquipmentItem = null!;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            cbUnits.SelectedValue = 0;
            txtWeight.Clear();
            cbUoM.SelectedValue = 0;

            MainPanel.Visible = true;
        }

        private void LoadEquipment()
        {
            List<ComboBoxViewModel> dataSource = new() {
                new ComboBoxViewModel(_equipmentId, txtSelectedEquipment.Text)
            };

            cbEquipment.DataSource = dataSource;

            cbEquipment.DisplayMember = "DisplayMember";
            cbEquipment.ValueMember = "ValueMember";

            cbEquipment.SelectedValue = _equipmentId;
        }

        private void LoadUoM()
        {
            List<ComboBoxViewModel> dataSource = new() {
                new ComboBoxViewModel(0, "Kgs"),
                new ComboBoxViewModel(1, "Lbs")
            };

            cbUoM.DataSource = dataSource;

            cbUoM.DisplayMember = "DisplayMember";
            cbUoM.ValueMember = "ValueMember";

            cbUoM.SelectedValue = 0;
        }

        private void LoadUnits()
        {
            List<ComboBoxViewModel> dataSource = new() {
                new ComboBoxViewModel(1, "1"),
                new ComboBoxViewModel(2, "2"),
                new ComboBoxViewModel(3, "3"),
                new ComboBoxViewModel(4, "4"),
                new ComboBoxViewModel(5, "5")
            };

            cbUnits.DataSource = dataSource;

            cbUnits.DisplayMember = "DisplayMember";
            cbUnits.ValueMember = "ValueMember";

            cbUnits.SelectedValue = 1;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (selectedEquipmentItemId > 0 && selectedEquipmentItem != null)
            {
                selectedEquipmentItem.Weight = decimal.Parse(txtWeight.Text);
                selectedEquipmentItem.Units = (int)cbUnits.SelectedValue;
                selectedEquipmentItem.UoM = cbUoM.Text;

                _equipmentItemRepository.Update(selectedEquipmentItem);
                _equipmentItemRepository.Commit();
            }
            else
            {
                var newItem = new EquipmentItem
                {
                    EquipmentId = _equipmentId,
                    Units = (int)cbUnits.SelectedValue,
                    UoM = cbUoM.Text,
                    Weight = decimal.Parse(txtWeight.Text)
                };

                _equipmentItemRepository.Add(newItem);
                _equipmentItemRepository.Commit();
            }

            dgItems.DataSource = null;

            LoadData();

            CancelButton_Click(this, null!);
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (selectedEquipmentItem != null)
            {
                cbUnits.SelectedValue = selectedEquipmentItem.Units;
                txtWeight.Text = selectedEquipmentItem.Weight.ToString();
                cbUoM.Text = selectedEquipmentItem.UoM;

                MainPanel.Visible = true;
            }
        }
    }
}
