namespace FTT.DbEntity
{
    public class ExerciseLoad : EntityIdentity
    {
        public int ExerciseId { get; set; }
        public decimal PreviousLoad { get; set; }
        public decimal CurrentLoad { get; set; }
        public string CurrentNotes { get; set; } = string.Empty;
        public DateTime LogDate { get; set; }
    }
}
