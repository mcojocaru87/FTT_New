using FTT.CustomControls;
using FTT.UserControls.CustomCalendar;
using FTT.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FTT
{
    public partial class WorkoutsForm : Form
    {

        public WorkoutsForm()
        {
            InitializeComponent();

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

            DateTime startOfMonth = new DateTime(year, month, 1);

            var daysInMonth = DateTime.DaysInMonth(year, month);

            var dayOfTheWeek = int.Parse(startOfMonth.DayOfWeek.ToString("d"));

            for (int i = 1; i <= dayOfTheWeek; i++)
            {
                BlankDay blankDay = new();
                daysContainer.Controls.Add(blankDay);
            }

            for (int i = 1; i <= daysInMonth; i++)
            {
                CalendarDay calendarDay = new();
                calendarDay.SetDays(i);
                daysContainer.Controls.Add(calendarDay);
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
            }
        }
    }
}
