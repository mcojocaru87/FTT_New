using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
