namespace FTT.DbEntity
{
    public class Setting : EntityIdentity
    {
        public int FailAttempts { get; set; }
        public int MaxReps { get; set; }
        public int MinReps { get; set; }
        public int ExerciseId { get; set; }
        public int MinSets { get; set; }
        public int RepRangeIntervalId { get; set; }
        public int ProgressTrys { get; set; }
    }
}
