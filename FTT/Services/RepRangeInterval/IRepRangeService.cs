using FTT.DbEntity;

namespace FTT.Services.RepRange;

public interface IRepRangeService
{
    bool CheckIfRepRangeIntervalExists(int minReps, int maxReps);
    RepRangeInterval? GetIntervalByRange(int minReps, int maxReps);
}
