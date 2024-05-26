using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTT
{
    public partial class ViewWorkoutForm : Form
    {
        private readonly int _workoutId;
        public ViewWorkoutForm(int workoutId)
        {
            InitializeComponent();

            _workoutId = workoutId;
        }


    }
}
