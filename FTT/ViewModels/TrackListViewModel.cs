namespace FTT.ViewModels
{
    public class TrackListViewModel
    {
        public int Reps { get; set; }
        public decimal Weight { get; set; }
        public int SetNumber { get; set; }
        public string Display { get; set; }

        public override string ToString()
        {
            return Display;
        }
    }
}
