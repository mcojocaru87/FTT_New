namespace FTT.DbEntity
{
    public class WorkoutItem : EntityIdentity
    {
        public int WorkoutId { get; set; }
        public int WorkingExerciseId { get; set; }
    }
}
