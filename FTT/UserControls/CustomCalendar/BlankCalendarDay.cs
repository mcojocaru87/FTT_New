namespace FTT.UserControls.CustomCalendar
{
    public partial class BlankCalendarDay : UserControl
    {
        public BlankCalendarDay()
        {
            InitializeComponent();
        }

        public void SetDays(int day)
        {
            lblDay.Text = day.ToString("00");
        }
    }
}
