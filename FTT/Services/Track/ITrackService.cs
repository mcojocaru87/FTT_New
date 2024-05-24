using FTT.DbEntity;
using FTT.ViewModels;

namespace FTT.Services.Track
{
    public interface ITrackService
    {
        bool LastExerciseTrackingExists(int exerciseId);
        int CreateWorkingExercise(WorkingExercise workingExercise);
        TrackingNotesViewModel? GetTrackingNotes(int exerciseId);
        LastTrackingViewModel? GetLastTracking(int exerciseId);
        void AddSetsToWorkingExercise(List<TrackListViewModel> list, int workingExerciseId);
        void FinishWorkingExercise(WorkingExercise workingExercise);
    }
}
