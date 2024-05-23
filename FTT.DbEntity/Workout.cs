using FTT.DbEntity;

namespace FTT.Enums
{
    public class Workout : EntityIdentity
    {
        public DateTime WorkoutDate { get; set; }
        public WorkoutStatus Status { get; set; }
    }
}
