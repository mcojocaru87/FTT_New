namespace FTT.DbEntity
{
    public class ProgressiveOverload : EntityIdentity
    {
        public int ExerciseId { get; set; }
        public decimal Weight { get; set; }
        public int Counter { get; set; }
        public int RepRangeIntervalId { get; set; }
        public DateTime LogDate { get; set; }
        public bool IsActive { get; set; }
    }
}
