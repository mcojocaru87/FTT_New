namespace FTT.DbEntity
{
    public class WorkingExerciseSet : EntityIdentity
    {
        public int WorkingExerciseId { get; set; }
        public int Reps { get; set; }
        public decimal Weight { get; set; }
        public int SetNumber { get; set; }
        public virtual WorkingExercise WorkingExercise { get; set; } = null!;
    }
}
