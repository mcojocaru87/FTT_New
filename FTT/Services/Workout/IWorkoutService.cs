using FTT.ViewModels;

namespace FTT.Services
{
    public interface IWorkoutService
    {
        void CreateWorkout(DateTime workoutDate);
        void FinishWorkout(int workoutId);
        void AddWorkingExerciseToWorkout(int workoutId, int workingExerciseId);
        void RemoveWorkingExerciseFromWorkout(int workoutId, int workingExerciseId);
        void UpdateWorkoutDate(int workoutId, DateTime newWorkoutDate);
        List<ViewWorkoutViewModel> GetAllWorkoutsDatesByMonth(int month, int year);
    }
}
