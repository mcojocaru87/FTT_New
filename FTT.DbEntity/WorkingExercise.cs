namespace FTT.DbEntity
{
    public class WorkingExercise : EntityIdentity
    {
        public int ExerciseId { get; set; }
        public DateTime WorkingDate { get; set; }
        public int FailCount { get; set; }
        public string Notes { get; set; } = string.Empty;
        public virtual ICollection<WorkingExerciseSet> WorkingExerciseSets { get; set; } = [];
    }
}
