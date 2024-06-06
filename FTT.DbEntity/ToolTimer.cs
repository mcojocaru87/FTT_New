namespace FTT.DbEntity
{
    public class ToolTimer : EntityIdentity
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        public bool IsDisplayed { get; set; }
    }
}
