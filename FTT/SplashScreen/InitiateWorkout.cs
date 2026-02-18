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

        public void CreateWorkout(int? templateId = null)
        {
            _workoutService?.CreateWorkout(DateTime.Now, templateId);
        }

        private void InitiateWorkout_Shown(object sender, EventArgs e)
        {
            
        }
    }
}
