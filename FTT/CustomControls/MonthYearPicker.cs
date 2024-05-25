using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTT.CustomControls
{
    public class MonthYearPicker : DateTimePicker
    {
        public MonthYearPicker()
        {
            this.Format = DateTimePickerFormat.Custom;
            this.CustomFormat = "MMMM yyyy";
            this.ShowUpDown = true;
        }

        protected override void OnDropDown(EventArgs eventargs)
        {
            base.OnDropDown(eventargs);
            SendMessage(this.Handle, DTM_SETMCSTYLE, 0, MCS_DAYSTATE);
        }

        protected override void OnValueChanged(EventArgs eventargs)
        {
            base.OnValueChanged(eventargs);
            this.CustomFormat = "MMMM yyyy";
        }

        private const int DTM_FIRST = 0x1000;
        private const int DTM_SETMCSTYLE = DTM_FIRST + 11;
        private const int MCS_DAYSTATE = 0x0001;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

    }
}
