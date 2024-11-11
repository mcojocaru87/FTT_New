using FTT.CustomControls;
using FTT.Services;
using FTT.UserControls.CustomCalendar;

namespace FTT
{
    public partial class WorkoutsForm : Form
    {
        private readonly IWorkoutService? _workoutService;

        public WorkoutsForm()
        {
            InitializeComponent();

            _workoutService = RegisteredServiceProvider.Instance.WorkoutService;

            DisplayDays();
        }

        private void DisplayDays()
        {
            DateTime now = DateTime.Now;

            SetCalendarDays(now.Month, now.Year);

            lblMonthYear.Text = now.ToString("MMMM yyyy");
        }

        private void SetCalendarDays(int month, int year)
        {
            daysContainer.Controls.Clear();

            var viewWorkouts = _workoutService?.GetAllWorkoutsDatesByMonth(month, year);

            DateTime startOfMonth = new DateTime(year, month, 1);

            var daysInMonth = DateTime.DaysInMonth(year, month);

            var dayOfTheWeek = int.Parse(startOfMonth.DayOfWeek.ToString("d"));

            dayOfTheWeek = dayOfTheWeek == 0 ? 7 : dayOfTheWeek;

            for (int i = 1; i < dayOfTheWeek; i++)
            {
                BlankDay blankDay = new();
                daysContainer.Controls.Add(blankDay);
            }

            for (int i = 1; i <= daysInMonth; i++)
            {
                if (viewWorkouts.Any(date => date.WorkoutDate.Day == i))
                {
                    var viewWorkout = viewWorkouts.FirstOrDefault(date => date.WorkoutDate.Day == i);

                    CalendarDay calendarDay = new();
                    calendarDay.SetDays(i);
                    calendarDay.SetWorkoutId(viewWorkout.WorkoutId);
                    daysContainer.Controls.Add(calendarDay);
                }
                else
                {
                    BlankCalendarDay blankCalendarDay = new();
                    blankCalendarDay.SetDays(i);
                    daysContainer.Controls.Add(blankCalendarDay);
                }
            }
        }

        private void dtMonthYear_ValueChanged(object sender, EventArgs e)
        {
            if (sender is MonthYearPicker picker)
            {
                var year = picker.Value.Year;
                var month = picker.Value.Month;

                SetCalendarDays(month, year);

                var now = new DateTime(year, month, 1);
                lblMonthYear.Text = now.ToString("MMMM yyyy");
            }
        }
    }
}
