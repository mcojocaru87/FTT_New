using FTT.DbEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTT.UserControls.ViewWorkout
{
    public partial class ViewWorkoutItem : UserControl
    {
        public ViewWorkoutItem()
        {
            InitializeComponent();
        }

        public void SetExerciseName(string exerciseName)
        {
            lblExerciseName.Text = exerciseName;
        }

        public void SetExerciseSets(List<WorkingExerciseSet> exerciseSets, int multiplier)
        {
            if (exerciseSets.Count > 0)
            {
                foreach (var item in exerciseSets)
                {
                    ViewWorkoutSet workoutSet = new();
                    workoutSet.SetLabel(item, multiplier);
                    MainPanel.Controls.Add(workoutSet);
                }
            }
        }

        private void MainPanel_Layout(object sender, LayoutEventArgs e)
        {
            MainPanel.AutoScrollPosition = new Point(0, MainPanel.AutoScrollPosition.Y);
        }
    }
}
