namespace FTT.ViewModels
{
    public class ProgressViewModel
    {
        public bool IsFullProgress { get; set; }
        public bool IsPartialProgress { get; set; }
        public int LeftSessionCount { get; set; }
        public bool IsNoProgress { get; set; }
    }
}
