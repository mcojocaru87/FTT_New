using FTT.DbEntity;

namespace FTT.Services.WorkoutTemplate
{
    public interface IWorkoutTemplateService
    {
        List<WorkoutTemplate> GetAllTemplates();
        WorkoutTemplate? GetTemplateById(int templateId);
        void SaveTemplate(int? templateId, string templateName, List<int> exerciseIds);
        void DeleteTemplate(int templateId);
    }
}
