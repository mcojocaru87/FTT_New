using FTT.UserControls.DataTables;
using FTT.UserControls.DataTables.ExerciseControls;
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
                new(2, "ToolTimers")
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
                        LoadExerciseDataTableUserControl();
                        ShowMainPanel(true);
                        break;
                    case 2:
                        LoadToolTimersDataTableUserControl();
                        ShowMainPanel(true);
                        break;
                }
            }
        }

        private void LoadExerciseDataTableUserControl()
        {
            ExerciseDTUC exerciseDTUC = new();

            SetupUserControl(exerciseDTUC);
        }

        private void LoadToolTimersDataTableUserControl()
        {
            ToolTimerDTUC toolTimerDTUC = new();

            SetupUserControl(toolTimerDTUC);
        }

        private void SetupUserControl(UserControl userControl)
        {
            MainPanel.Controls.Clear();

            userControl.Dock = DockStyle.Fill;
            MainPanel.Controls.Add(userControl);
        }

        private void ShowMainPanel(bool visible)
        {
            MainPanel.Visible = visible;
        }
    }
}
