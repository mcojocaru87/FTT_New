using FTT.DbEntity;

namespace FTT.Enums
{
    public class Workout : EntityIdentity
    {
        public DateTime WorkoutDate { get; set; }
        public WorkoutStatus Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsProgressMade { get; set; }
    }
}
