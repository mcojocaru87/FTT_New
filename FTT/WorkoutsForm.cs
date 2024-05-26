using FTT.CustomControls;
using FTT.Services;
using FTT.UserControls.CustomCalendar;
using Microsoft.Extensions.DependencyInjection;

namespace FTT
{
    public partial class WorkoutsForm : Form
    {
        private readonly IWorkoutService _workoutService;

        public WorkoutsForm()
        {
            InitializeComponent();

            _workoutService = Session.Instance.ServiceProvider.GetRequiredService<IWorkoutService>();

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

            var workoutDates = _workoutService.GetAllWorkoutsDatesByMonth(month, year);

            DateTime startOfMonth = new DateTime(year, month, 1);

            var daysInMonth = DateTime.DaysInMonth(year, month);

            var dayOfTheWeek = int.Parse(startOfMonth.DayOfWeek.ToString("d"));

            for (int i = 1; i < dayOfTheWeek; i++)
            {
                BlankDay blankDay = new();
                daysContainer.Controls.Add(blankDay);
            }

            for (int i = 1; i <= daysInMonth; i++)
            {
                if (workoutDates.Any(date => date.Day == i))
                {
                    CalendarDay calendarDay = new();
                    calendarDay.SetDays(i);
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
            MonthYearPicker picker = sender as MonthYearPicker;

            if (picker != null)
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
