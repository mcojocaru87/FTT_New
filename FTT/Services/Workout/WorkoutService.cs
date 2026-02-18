using FTT.DataAccesss;
using FTT.DbEntity;
using FTT.Enums;
using FTT.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace FTT.Services
{
    public class WorkoutService : IWorkoutService
    {
        private readonly IRepository<Workout> _workoutRepository;
        private readonly IRepository<WorkoutItem> _workoutItemRepository;
        private readonly IRepository<WorkoutTemplateExercise> _templateExerciseRepository;
        public WorkoutService()
        {
            _workoutRepository = Session.Instance.ServiceProvider.GetRequiredService<IRepository<Workout>>();
            _workoutItemRepository = Session.Instance.ServiceProvider.GetRequiredService<IRepository<WorkoutItem>>();
            _templateExerciseRepository = Session.Instance.ServiceProvider.GetRequiredService<IRepository<WorkoutTemplateExercise>>();
        }

        public void CreateWorkout(DateTime workoutDate, int? workoutTemplateId = null)
        {
            var newWorkout = new Workout
            {
                Status = WorkoutStatus.InProgress,
                WorkoutDate = workoutDate,
                StartDate = DateTime.Now,
                WorkoutTemplateId = workoutTemplateId
            };

            _workoutRepository.Add(newWorkout);
            _workoutRepository.Commit();

            Session.Instance.ActiveWorkoutId = newWorkout.Id;
        }

        public void AddWorkingExerciseToWorkout(int workoutId, int workingExerciseId)
        {
            var workoutItems = _workoutItemRepository
                .Find(x => x.WorkingExerciseId == workingExerciseId && x.WorkoutId == workoutId);

            if (!workoutItems.Any())
            {
                var workoutItem = new WorkoutItem
                {
                    WorkoutId = workoutId,
                    WorkingExerciseId = workingExerciseId
                };

                _workoutItemRepository.Add(workoutItem);
                _workoutItemRepository.Commit();
            }
        }

        public void RemoveWorkingExerciseFromWorkout(int workoutId, int workingExerciseId)
        {
            var workoutItem = _workoutItemRepository
                .Find(x => x.WorkingExerciseId == workingExerciseId && x.WorkoutId == workoutId)
                .FirstOrDefault();

            if (workoutItem != null)
            {
                _workoutItemRepository.Delete(workoutItem);
                _workoutItemRepository.Commit();
            }
        }

        public void FinishWorkout(int workoutId)
        {
            var workout = _workoutRepository.GetById(workoutId);

            if (workout != null)
            {
                var workoutItems = _workoutItemRepository
                    .Find(x => x.WorkoutId == workoutId)
                    .ToList();

                if (workoutItems.Count > 0)
                {
                    workout.Status = WorkoutStatus.Finished;
                    workout.EndDate = DateTime.Now;
                    workout.IsProgressMade = Session.Instance.IsActiveWorkoutProgressMade;

                    _workoutRepository.Update(workout);
                    _workoutRepository.Commit();
                }
                else
                {
                    _workoutRepository.Delete(workout);
                    _workoutRepository.Commit();
                }
            }

            Session.Instance.ActiveWorkoutId = null;
            Session.Instance.IsActiveWorkoutProgressMade = false;
        }

        public void UpdateWorkoutDate(int workoutId, DateTime newWorkoutDate)
        {
            var workout = _workoutRepository.GetById(workoutId);

            if (workout != null)
            {
                workout.WorkoutDate = newWorkoutDate;

                _workoutRepository.Update(workout);
                _workoutRepository.Commit();
            }
        }

        public List<ViewWorkoutViewModel> GetAllWorkoutsDatesByMonth(int month, int year)
        {
            return [.. _workoutRepository
                .Find(x => x.WorkoutDate.Month == month && x.WorkoutDate.Year == year)
                .Select(x=> new ViewWorkoutViewModel{ WorkoutDate = x.WorkoutDate, WorkoutId = x.Id })
                .Distinct()];
        }

        public WorkoutAggregateViewModel GetWorkoutById(int workoutId)
        {
            var workout = _workoutRepository.GetById(workoutId);
            var result = new WorkoutAggregateViewModel();

            if (workout != null)
            {
                var workoutItems = _workoutItemRepository
                    .Find(x => x.WorkoutId == workoutId)
                    .ToList();

                result = new()
                {
                    Workout = workout,
                    WorkoutItems = workoutItems
                };
            }

            return result;
        }

        public List<int> GetTemplateExerciseIdsForWorkout(int workoutId)
        {
            var workout = _workoutRepository.GetById(workoutId);

            if (workout?.WorkoutTemplateId == null)
            {
                return [];
            }

            return [.. _templateExerciseRepository
                .Find(x => x.WorkoutTemplateId == workout.WorkoutTemplateId)
                .Select(x => x.ExerciseId)
                .Distinct()];
        }
    }
}
