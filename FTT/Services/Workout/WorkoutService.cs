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
        public WorkoutService()
        {
            _workoutRepository = Session.Instance.ServiceProvider.GetRequiredService<IRepository<Workout>>();
            _workoutItemRepository = Session.Instance.ServiceProvider.GetRequiredService<IRepository<WorkoutItem>>();
        }

        public void CreateWorkout(DateTime workoutDate)
        {
            var newWorkout = new Workout { Status = WorkoutStatus.InProgress, WorkoutDate = workoutDate };

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
    }
}
