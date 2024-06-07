using System.ComponentModel.DataAnnotations.Schema;

namespace FTT.DbEntity
{
    public class RepRangeInterval : EntityIdentity
    {
        [NotMapped]
        public virtual string ExerciseName { get; set; } = string.Empty;

        public int ExerciseId { get; set; }
        public int MinReps { get; set; }
        public int MaxReps { get; set; }
        public bool IsSelected { get; set; }
    }
}
