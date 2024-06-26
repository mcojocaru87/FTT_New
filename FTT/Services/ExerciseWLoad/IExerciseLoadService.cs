using FTT.DbEntity;
using FTT.ViewModels;

namespace FTT.Services.ExerciseWLoad
{
    public interface IExerciseLoadService
    {
        void UpdateExerciseLoad(int exerciseId, decimal load, string notes);
        ExerciseLoad? GetExerciseLoadByExerciseId(int exerciseId);
        NextLoadViewModel GetNextLoad(decimal currentWeight, bool isDumbbell, bool isIncrease);
    }
}
