using FTT.DbEntity;
using FTT.Enums;

namespace FTT.ViewModels
{
    public class WorkoutAggregateViewModel
    {
        public Workout Workout { get; set; } = null!;

        public List<WorkoutItem> WorkoutItems { get; set; } = [];
    }
}
