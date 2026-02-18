using FTT.Services;
using FTT.UserControls;

namespace FTT
{
    public partial class MainForm : Form
    {
        private readonly IWorkoutService? workoutService = RegisteredServiceProvider.Instance.WorkoutService;

        public MainForm()
        {
            InitializeComponent();

            TrackButton.Enabled = false;
        }

        public Button BeginWorkoutBtn => BeginWorkoutButton;
        public Button TrackBtn => TrackButton;
        public Button SettingsBtn => SettingsButton;
        public Button DatabaseBtn => DatabaseButton;
        public Button WorkoutsBtn => WorkoutsButton;

        private void DatabaseButton_Click(object sender, EventArgs e)
        {
            LoadDatabaseUserControl();
        }

        private void LoadDatabaseUserControl()
        {
            DatabaseUC databaseUserControl = new();

            SetupUserControl(databaseUserControl);
        }

        private void LoadSettingsUserControl()
        {
            SettingsUC settingsUserControl = new();

            SetupUserControl(settingsUserControl);
        }

        private void LoadTrackUserControl()
        {
            TrackUC trackUserControl = new(this);
            trackUserControl.TriggerButtonEvent += BeginWorkoutButton_Click!;

            SetupUserControl(trackUserControl);
        }

        private void SetupUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;

            MainPanel.Controls.Clear();

            MainPanel.Controls.Add(userControl);
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            LoadSettingsUserControl();
        }

        private void TrackButton_Click(object sender, EventArgs e)
        {
            LoadTrackUserControl();
        }

        private void BeginWorkoutButton_Click(object sender, EventArgs e)
        {
            var buttonText = BeginWorkoutButton.Text;

            if (buttonText == "Begin Workout")
            {
                using var selectTemplateForm = new SelectWorkoutTemplateForm();
                var selectResult = selectTemplateForm.ShowDialog(this);

                if (selectResult != DialogResult.OK)
                {
                    return;
                }

                BeginWorkoutButton.Text = "Finish Workout";

                InitiateWorkout initiateWorkout = new();
                initiateWorkout.CreateWorkout(selectTemplateForm.SelectedTemplateId);
                                
                SetupWorkoutStatusPanel(true);

                TrackButton.Enabled = true;
            }
            else
            {
                BeginWorkoutButton.Text = "Begin Workout";

                if (Session.Instance.ActiveWorkoutId != null && Session.Instance.ActiveWorkoutId > 0)
                {
                    workoutService?.FinishWorkout((int)Session.Instance.ActiveWorkoutId);
                }

                SetupWorkoutStatusPanel(false);

                TrackButton.Enabled = false;

                MainPanel.Controls.Clear();

                MessageBox.Show("Workout successfully finished!", "Workout Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SetupWorkoutStatusPanel(bool isActive) => WorkoutStatusPanel.Visible = isActive;

        private void WorkoutsButton_Click(object sender, EventArgs e)
        {
            var workoutsForm = new WorkoutsForm();

            workoutsForm.ShowDialog();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Session.Instance.ActiveWorkoutId != null && Session.Instance.ActiveWorkoutId > 0)
            {
                var result = MessageBox.Show("You have unsaved workout. Please finish the workout before exiting!", "Unsaved Changes", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (result == DialogResult.OK)
                {
                    e.Cancel = true;
                }
            }
        }

        private void CalculatorButton_Click(object sender, EventArgs e)
        {
            CalculatorForm calculatorForm = new();

            calculatorForm.ShowDialog();
        }

        private void ClockButton_Click(object sender, EventArgs e)
        {
            TimerForm timerForm = new(false, true);
            timerForm.Show();
        }

        private void TemplateButton_Click(object sender, EventArgs e)
        {
            using var workoutTemplateForm = new WorkoutTemplateForm();
            workoutTemplateForm.ShowDialog(this);
        }
    }
}
