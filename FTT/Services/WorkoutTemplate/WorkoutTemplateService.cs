using FTT.DataAccesss;
using FTT.DbEntity;
using Microsoft.Extensions.DependencyInjection;

namespace FTT.Services.WorkoutTemplate
{
    public class WorkoutTemplateService : IWorkoutTemplateService
    {
        private readonly IRepository<WorkoutTemplate> _templateRepository;
        private readonly IRepository<WorkoutTemplateExercise> _templateExerciseRepository;

        public WorkoutTemplateService()
        {
            _templateRepository = Session.Instance.ServiceProvider.GetRequiredService<IRepository<WorkoutTemplate>>();
            _templateExerciseRepository = Session.Instance.ServiceProvider.GetRequiredService<IRepository<WorkoutTemplateExercise>>();
        }

        public List<WorkoutTemplate> GetAllTemplates()
        {
            return [.. _templateRepository.GetAll().OrderBy(x => x.Name)];
        }

        public WorkoutTemplate? GetTemplateById(int templateId)
        {
            return _templateRepository.GetById(templateId, true, "Exercises");
        }

        public void SaveTemplate(int? templateId, string templateName, List<int> exerciseIds)
        {
            if (templateId is null or 0)
            {
                var newTemplate = new WorkoutTemplate { Name = templateName.Trim() };

                _templateRepository.Add(newTemplate);
                _templateRepository.Commit();

                foreach (var exerciseId in exerciseIds.Distinct())
                {
                    _templateExerciseRepository.Add(new WorkoutTemplateExercise
                    {
                        WorkoutTemplateId = newTemplate.Id,
                        ExerciseId = exerciseId
                    });
                }

                _templateExerciseRepository.Commit();

                return;
            }

            var existingTemplate = _templateRepository.GetById(templateId.Value);

            if (existingTemplate == null)
            {
                return;
            }

            existingTemplate.Name = templateName.Trim();
            _templateRepository.Update(existingTemplate);

            var existingExercises = _templateExerciseRepository
                .Find(x => x.WorkoutTemplateId == templateId.Value)
                .ToList();

            foreach (var item in existingExercises)
            {
                _templateExerciseRepository.Delete(item);
            }

            foreach (var exerciseId in exerciseIds.Distinct())
            {
                _templateExerciseRepository.Add(new WorkoutTemplateExercise
                {
                    WorkoutTemplateId = templateId.Value,
                    ExerciseId = exerciseId
                });
            }

            _templateRepository.Commit();
        }

        public void DeleteTemplate(int templateId)
        {
            var template = _templateRepository.GetById(templateId);

            if (template == null)
            {
                return;
            }

            var templateExercises = _templateExerciseRepository
                .Find(x => x.WorkoutTemplateId == templateId)
                .ToList();

            foreach (var exercise in templateExercises)
            {
                _templateExerciseRepository.Delete(exercise);
            }

            _templateRepository.Delete(template);
            _templateRepository.Commit();
        }
    }
}
