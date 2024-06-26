using FTT.Services;
using FTT.Services.Track;
using FTT.UserControls.ViewWorkout;

namespace FTT
{
    public partial class ViewWorkoutForm : Form
    {
        private readonly int _workoutId;
        private readonly IWorkoutService? _workoutService = RegisteredServiceProvider.Instance.WorkoutService;
        private readonly ITrackService? _trackService = RegisteredServiceProvider.Instance.TrackService;

        public ViewWorkoutForm(int workoutId)
        {
            InitializeComponent();

            _workoutId = workoutId;            

            LoadWorkout();
        }

        public void LoadWorkout()
        {
            var workout = _workoutService?.GetWorkoutById(_workoutId);

            if (workout != null && workout.Workout != null)
            {
                lblWorkoutDate.Text = workout.Workout.WorkoutDate.ToString("MMMM dd, yyyy");

                if (workout.WorkoutItems.Count > 0)
                {
                    foreach (var item in workout.WorkoutItems)
                    {
                        var workingExercise = _trackService?.GetWorkingExerciseById(item.WorkingExerciseId);

                        if (workingExercise != null)
                        {
                            var exercise = _trackService?.GetExercise(workingExercise.ExerciseId);
                            var workingExerciseSets = _trackService?.GetWorkingExerciseSets(workingExercise.Id);

                            if (exercise != null)
                            {
                                ViewWorkoutItem workoutItem = new();
                                workoutItem.SetExerciseName(exercise.Name);
                                workoutItem.SetExerciseSets(workingExerciseSets, exercise.Multiplier);
                                MainPanel.Controls.Add(workoutItem);
                            }
                        }
                    }
                }
            }
        }

        private void MainPanel_Layout(object sender, LayoutEventArgs e)
        {
            MainPanel.AutoScrollPosition = new Point(0, MainPanel.AutoScrollPosition.Y);
        }
    }
}
