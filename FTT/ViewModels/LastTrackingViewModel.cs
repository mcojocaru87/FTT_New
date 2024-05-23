using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTT.ViewModels
{
    public class LastTrackingViewModel
    {
        public DateTime WorkingDate { get; set; }
        public decimal TotalVolume { get; set; }
        public int TotalSets { get; set; }
        public List<LastWorkingSetViewModel> WorkingSets { get; set; } = [];
    }

    public class LastWorkingSetViewModel
    {
        public int SetNumber { get; set; }
        public int Reps { get; set; }
        public decimal Weight { get; set; }
        public int Multiplier { get; set; }
    }
}
