using FTT.DbEntity;
using FTT.ViewModels;
using System.Data;

namespace FTT.Services.Track
{
    public interface ITrackService
    {
        bool LastExerciseTrackingExists(int exerciseId);
        int CreateWorkingExercise(WorkingExercise workingExercise);
        TrackingNotesViewModel? GetTrackingNotes(int exerciseId, int repRangeIntervalId);
        LastTrackingViewModel? GetLastTracking(int exerciseId, int repRangeIntervalId);
        void AddSetsToWorkingExercise(List<TrackListViewModel> list, int workingExerciseId);
        void FinishWorkingExercise(WorkingExercise workingExercise);
        List<HistoryViewModel> GetWorkingExerciseHistory(int exerciseId, int repRangeIntervalId);
        DataTable ConvertToDataTable(List<HistoryViewModel> list);
        WorkingExercise GetWorkingExerciseById(int workingExerciseId);
        Exercise GetExercise(int exerciseId);
        List<WorkingExerciseSet> GetWorkingExerciseSets(int workingExerciseId);
    }
}
