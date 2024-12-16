using FTT.DataAccesss;
using FTT.DbEntity;

namespace FTT.Services.RepRange;

public class RepRangeService : IRepRangeService
{
    private readonly IRepository<RepRangeInterval> _repRangeIntervalRepository = RegisteredServiceProvider.Instance.IntervalRepository!;

    public bool CheckIfRepRangeIntervalExists(int minReps, int maxReps)
    {
        var interval = _repRangeIntervalRepository
            .Find(x => x.MinReps == minReps && x.MaxReps == maxReps)
            .FirstOrDefault();

        return interval != null;
    }

    public RepRangeInterval? GetIntervalByRange(int minReps, int maxReps)
    {
        return _repRangeIntervalRepository
             .Find(x => x.MinReps == minReps && x.MaxReps == maxReps)
             .FirstOrDefault();
    }


}
