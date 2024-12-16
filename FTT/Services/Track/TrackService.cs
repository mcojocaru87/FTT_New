using FTT.DataAccesss;
using FTT.DbEntity;
using FTT.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

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

        public TrackingNotesViewModel? GetTrackingNotes(int exerciseId, int repRangeIntervalId)
        {
            var workingExercise = GetLastWorkingExercise(exerciseId, repRangeIntervalId);

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

        public LastTrackingViewModel? GetLastTracking(int exerciseId, int repRangeIntervalId)
        {
            var workingExercise = GetLastWorkingExercise(exerciseId, repRangeIntervalId);

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

        private WorkingExercise? GetLastWorkingExercise(int exerciseId, int repRangeIntervalId)
        {
            if (repRangeIntervalId > 0)
            {
                return _workingExerciseRepository
               .Find(x => x.ExerciseId == exerciseId && x.RepRangeIntervalId == repRangeIntervalId)
               .Include("WorkingExerciseSets")
               .Where(x => x.WorkingExerciseSets.Any())
               .OrderByDescending(x => x.WorkingDate)
               .FirstOrDefault();
            }

            return _workingExerciseRepository
               .Find(x => x.ExerciseId == exerciseId)
               .Include("WorkingExerciseSets")
               .Where(x => x.WorkingExerciseSets.Any())
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
                    Reps = item.Reps,
                    SetNumber = item.SetNumber,
                    Weight = item.Weight,
                    WorkingExerciseId = workingExerciseId
                };

                _workingExerciseSetRepository.Add(set);
            }

            _workingExerciseSetRepository.Commit();
        }

        public Exercise GetExercise(int exerciseId)
        {
            return _exerciseRepository.GetById(exerciseId);
        }

        public void FinishWorkingExercise(WorkingExercise workingExercise)
        {
            var workingExerciseToUpdate = _workingExerciseRepository.GetById(workingExercise.Id);

            if (workingExerciseToUpdate != null)
            {
                workingExerciseToUpdate.WorkingDate = workingExercise.WorkingDate;
                workingExerciseToUpdate.FailCount = workingExercise.FailCount;
                workingExerciseToUpdate.Notes = workingExercise.Notes;
                workingExerciseToUpdate.RepRangeIntervalId = workingExercise.RepRangeIntervalId;    

                _workingExerciseRepository.Update(workingExerciseToUpdate);
                _workingExerciseRepository.Commit();
            }
        }

        public List<HistoryViewModel> GetWorkingExerciseHistory(int exerciseId, int repRangeIntervalId)
        {
            List<HistoryViewModel> viewModel = [];
            List<WorkingExercise> workingExercises = [];

            if (repRangeIntervalId > 0)
            {
                workingExercises = [.. _workingExerciseRepository
               .Find(x => x.ExerciseId == exerciseId && x.RepRangeIntervalId == repRangeIntervalId)
               .OrderByDescending(x => x.WorkingDate)];
            }
            else
            {
                workingExercises = [.. _workingExerciseRepository
               .Find(x => x.ExerciseId == exerciseId)
               .OrderByDescending(x => x.WorkingDate)];
            }



            var exercise = GetExercise(exerciseId);
            var multiplier = exercise.Multiplier;

            foreach (var item in workingExercises)
            {
                var viewModelItem = new HistoryViewModel();

                var workingExerciseSets = _workingExerciseSetRepository
                    .Find(x => x.WorkingExerciseId == item.Id)
                    .OrderBy(x => x.SetNumber)
                    .ToList();

                var volume = workingExerciseSets.Sum(x => x.Reps * x.Weight * multiplier);

                viewModelItem["Date"] = item.WorkingDate.ToString("MMM dd, yyyy");
                viewModelItem["Failed"] = item.FailCount;
                viewModelItem["Volume"] = $"{volume} Kg";

                foreach (var set in workingExerciseSets)
                {
                    viewModelItem[$"Set{set.SetNumber}"] = $"R{set.Reps} x W{set.Weight}{(multiplier > 1 ? $" x {multiplier}" : string.Empty)}";
                }

                if (volume > 0)
                {
                    viewModel.Add(viewModelItem);
                }
            }

            return viewModel;
        }

        public DataTable ConvertToDataTable(List<HistoryViewModel> list)
        {
            DataTable dataTable = new();

            if (list == null || list.Count == 0)
            {
                return dataTable;
            }

            var propertyNames = list
                .SelectMany(x => x.GetProperties().Keys)
                .Distinct()
                .ToList();

            foreach (var property in propertyNames)
            {
                dataTable.Columns.Add(property);
            }

            foreach (var item in list)
            {
                var row = dataTable.NewRow();
                foreach (var property in item.GetProperties())
                {
                    row[property.Key] = property.Value ?? DBNull.Value;
                }
                dataTable.Rows.Add(row);
            }
            return dataTable;
        }

        public WorkingExercise GetWorkingExerciseById(int workingExerciseId)
        {
            return _workingExerciseRepository.GetById(workingExerciseId);
        }

        public List<WorkingExerciseSet> GetWorkingExerciseSets(int workingExerciseId)
        {
            return [.. _workingExerciseSetRepository.Find(x => x.WorkingExerciseId == workingExerciseId)];
        }
    }
}
