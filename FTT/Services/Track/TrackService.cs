using FTT.DataAccesss;
using FTT.DbEntity;
using FTT.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace FTT.Services.Track
{
    public class TrackService : ITrackService
    {
        private readonly IRepository<WorkingExercise> _workingExerciseRepository;
        private readonly IRepository<WorkingExerciseSet> _workingExerciseSetRepository;
        private readonly IRepository<Exercise> _exerciseRepository;

        public TrackService()
        {
            _workingExerciseRepository = Session.Instance.ServiceProvider.GetRequiredService<IRepository<WorkingExercise>>();
            _workingExerciseSetRepository = Session.Instance.ServiceProvider.GetRequiredService<IRepository<WorkingExerciseSet>>();
            _exerciseRepository = Session.Instance.ServiceProvider.GetRequiredService<IRepository<Exercise>>();
        }

        public bool LastExerciseTrackingExists(int exerciseId)
        {
            return _workingExerciseRepository
                .Find(x => x.ExerciseId == exerciseId).Count() > 0;
        }

        public int CreateWorkingExercise(WorkingExercise workingExercise)
        {
            _workingExerciseRepository.Add(workingExercise);
            _workingExerciseRepository.Commit();

            return workingExercise.Id;
        }

        public TrackingNotesViewModel? GetTrackingNotes(int exerciseId)
        {
            var workingExercise = GetLastWorkingExercise(exerciseId);

            if (workingExercise != null)
            {
                return new TrackingNotesViewModel
                {
                    Notes = workingExercise.Notes,
                    StrikeCount = workingExercise.FailCount
                };
            }

            return null; ;
        }

        public LastTrackingViewModel? GetLastTracking(int exerciseId)
        {
            var workingExercise = GetLastWorkingExercise(exerciseId);

            if (workingExercise != null)
            {
                var sets = GetLastWorkingExerciseSets(workingExercise.Id);

                if (sets.Count > 0)
                {
                    var exercise = GetExercise(exerciseId);
                    var multiplier = exercise.Multiplier;
                    var totalVolume = sets.Sum(x => x.Reps * x.Weight * multiplier);

                    List<LastWorkingSetViewModel> workingSets = [];

                    foreach (var set in sets)
                    {
                        workingSets.Add(new LastWorkingSetViewModel
                        {
                            Multiplier = multiplier,
                            Reps = set.Reps,
                            Weight = set.Weight,
                            SetNumber = set.SetNumber
                        });
                    }

                    return new LastTrackingViewModel
                    {
                        TotalSets = sets.Count,
                        WorkingDate = workingExercise.WorkingDate,
                        TotalVolume = totalVolume,
                        WorkingSets = workingSets
                    };
                }
            }

            return null;
        }

        private WorkingExercise? GetLastWorkingExercise(int exerciseId)
        {
            return _workingExerciseRepository
                .Find(x => x.ExerciseId == exerciseId)
                .OrderByDescending(x => x.WorkingDate)
                .FirstOrDefault();
        }

        private List<WorkingExerciseSet> GetLastWorkingExerciseSets(int workingExerciseId)
        {
            return _workingExerciseSetRepository
                .Find(x => x.WorkingExerciseId == workingExerciseId)
                .ToList();
        }

        public void AddSetsToWorkingExercise(List<TrackListViewModel> list, int workingExerciseId)
        {
            foreach (var item in list)
            {
                var set = new WorkingExerciseSet
                {
                    Reps = item.SetNumber,
                    SetNumber = item.SetNumber,
                    Weight = item.Weight,
                    WorkingExerciseId = workingExerciseId
                };

                _workingExerciseSetRepository.Add(set);
            }

            _workingExerciseSetRepository.Commit();
        }

        private Exercise GetExercise(int exerciseId)
        {
            return _exerciseRepository.GetById(exerciseId);
        }
    }
}
