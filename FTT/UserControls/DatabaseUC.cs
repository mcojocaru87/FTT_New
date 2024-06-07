using FTT.UserControls.DataTables.EquipmentControls;
using FTT.UserControls.DataTables.ExerciseControls;
using FTT.UserControls.DataTables.RepRangeIntervalControls;
using FTT.UserControls.DataTables.ToolTimerControls;
using FTT.ViewModels;

namespace FTT.UserControls
{
    public partial class DatabaseUC : UserControl
    {
        public DatabaseUC()
        {
            InitializeComponent();

            LoadDataTables();
        }

        private void LoadDataTables()
        {
            cbDataTable.DataSource = AvailableDataTables();

            cbDataTable.ValueMember = "ValueMember";
            cbDataTable.DisplayMember = "DisplayMember";
        }

        private static List<ComboBoxViewModel> AvailableDataTables()
        {
            return [
                new(0, "-- Please Select --"),
                new(1, "Exercises"),
                new(2, "ToolTimers"),
                new(3, "Equipments"),
                new(4, "RepRangeIntervals")
                ];
        }

        private void cbDataTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxViewModel selectedDataTable = cbDataTable.SelectedItem as ComboBoxViewModel;

            if (selectedDataTable != null)
            {
                switch (selectedDataTable.ValueMember)
                {
                    case 0:
                        MainPanel.Controls.Clear();
                        ShowMainPanel(false);
                        break;
                    case 1:
                        SetupUserControl(new ExerciseDTUC());
                        break;
                    case 2:
                        SetupUserControl(new ToolTimerDTUC());
                        break;
                    case 3:
                        SetupUserControl(new EquipmentDTUC());
                        break;
                    case 4:
                        SetupUserControl(new RepRangeIntervalDTUC());
                        break;
                }
            }
        }

        private void SetupUserControl(UserControl userControl)
        {
            MainPanel.Controls.Clear();

            userControl.Dock = DockStyle.Fill;
            MainPanel.Controls.Add(userControl);

            ShowMainPanel(true);
        }

        private void ShowMainPanel(bool visible)
        {
            MainPanel.Visible = visible;
        }
    }
}
