namespace FTT.UserControls.CustomCalendar
{
    public partial class CalendarDay : UserControl
    {
        public CalendarDay()
        {
            InitializeComponent();
        }

        public void SetDays(int day)
        {
            lblDay.Text = day.ToString("00");
        }

        public void SetWorkoutId(int workoutId)
        {
            lblViewWorkout.Tag = workoutId;
        }

        private void lblViewWorkout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var link = sender as LinkLabel;

            if (link != null)
            {
                int? workoutId = link.Tag as int?;

                if (workoutId.HasValue)
                {
                    ViewWorkoutForm viewWorkoutForm = new(workoutId.Value);

                    viewWorkoutForm.ShowDialog();
                }
            }
        }
    }
}
