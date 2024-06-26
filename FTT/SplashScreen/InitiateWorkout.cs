using FTT.Services;

namespace FTT
{
    public partial class InitiateWorkout : Form
    {
        private readonly IWorkoutService? _workoutService;

        public InitiateWorkout()
        {
            InitializeComponent();

            _workoutService = RegisteredServiceProvider.Instance.WorkoutService;
        }

        private void SimulateLoading()
        {
            for (int i = 0; i <= 50; i++)
            {
                progressBar.Value = i;
                Thread.Sleep(10); // Simulate loading
            }

            _workoutService?.CreateWorkout(DateTime.Now);

            for (int i = 51; i <= 100; i++)
            {
                progressBar.Value = i;
                Thread.Sleep(10); // Simulate loading
            }

            this.Close();
        }

        private void InitiateWorkout_Shown(object sender, EventArgs e)
        {
            SimulateLoading();
        }
    }
}
