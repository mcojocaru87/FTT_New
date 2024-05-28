using FTT.DbEntity;

namespace FTT.UserControls.ViewWorkout
{
    public partial class ViewWorkoutSet : UserControl
    {
        public ViewWorkoutSet()
        {
            InitializeComponent();
        }

        public void SetLabel(WorkingExerciseSet set, int multiplier)
        {
            lblSet.Text = string.Format("R{0} x W{1}{2}", set.Reps, set.Weight, multiplier > 1 ? $" x {multiplier}" : string.Empty);
        }
    }
}
