namespace FTT.DbEntity
{
    public class WorkoutTemplate : EntityIdentity
    {
        public string Name { get; set; } = string.Empty;
        public virtual ICollection<WorkoutTemplateExercise> Exercises { get; set; } = [];
    }
}
