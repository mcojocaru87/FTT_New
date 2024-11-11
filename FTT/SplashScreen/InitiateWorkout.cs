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

        public void CreateWorkout() {
            _workoutService?.CreateWorkout(DateTime.Now);
        }

        private void InitiateWorkout_Shown(object sender, EventArgs e)
        {
            
        }
    }
}
