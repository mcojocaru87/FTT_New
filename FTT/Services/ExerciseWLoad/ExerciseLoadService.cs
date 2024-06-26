using FTT.DataAccesss;
using FTT.DbEntity;
using FTT.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FTT.Services.ExerciseWLoad
{
    public class ExerciseLoadService : IExerciseLoadService
    {
        private readonly IRepository<ExerciseLoad> _exerciseLoadRepository;
        private readonly IRepository<Equipment> _equipmentRepository;

        public ExerciseLoadService()
        {
            _exerciseLoadRepository = Session.Instance.ServiceProvider.GetRequiredService<IRepository<ExerciseLoad>>();
            _equipmentRepository = Session.Instance.ServiceProvider.GetRequiredService<IRepository<Equipment>>();
        }

        public void UpdateExerciseLoad(int exerciseId, decimal load, string notes)
        {
            var exerciseLoad = _exerciseLoadRepository
                .Find(x => x.ExerciseId == exerciseId)
                .FirstOrDefault();

            if (exerciseLoad == null)
            {
                CreateExerciseLoad(exerciseId, load, notes);
            }
            else
            {
                var previousLoad = exerciseLoad.CurrentLoad;

                exerciseLoad.CurrentLoad = load;
                exerciseLoad.PreviousLoad = previousLoad;
                exerciseLoad.CurrentNotes = notes;
                exerciseLoad.LogDate = DateTime.Now;

                _exerciseLoadRepository.Update(exerciseLoad);
                _exerciseLoadRepository.Commit();
            }
        }

        public ExerciseLoad? GetExerciseLoadByExerciseId(int exerciseId)
        {
            return _exerciseLoadRepository
                .Find(x => x.ExerciseId == exerciseId)
                .FirstOrDefault();
        }

        public NextLoadViewModel GetNextLoad(decimal currentWeight, bool isDumbbell, bool isIncrease)
        {
            IQueryable<Equipment> equipment = null!;
            List<EquipmentItem> equipmentItems = new();

            if (isDumbbell)
            {
                equipment = _equipmentRepository
                    .Find(x => x.IsDumbbell == true);
            }
            else
            {
                equipment = _equipmentRepository
                   .Find(x => x.IsPlate == true);
            }

            if (equipment != null && equipment.Any())
            {
                var aggregate = equipment
                    .Include(x => x.Items)
                    .FirstOrDefault();

                if (aggregate?.Items != null && aggregate.Items.Count > 0)
                {
                    decimal nextWeight = 0;
                    bool isMin = false;
                    bool isMax = false;

                    var maxWeight = aggregate.Items.Max(x => x.Weight);
                    var minWeight = aggregate.Items.Min(x => x.Weight);
                    
                    if (isIncrease)
                    {
                        if (currentWeight >= maxWeight)
                        {
                            return new NextLoadViewModel
                            {
                                IsMax = true,
                                IsMin = isMin,
                                Weight = maxWeight
                            };
                        }

                        nextWeight = aggregate.Items
                            .Where(x => x.Weight > currentWeight)
                            .Min(x => x.Weight);
                    }
                    else
                    {
                        if (currentWeight <= minWeight)
                        {
                            return new NextLoadViewModel
                            {
                                IsMax = isMax,
                                IsMin = true,
                                Weight = minWeight
                            };
                        }

                        nextWeight = aggregate.Items
                            .Where(x => x.Weight < currentWeight)
                            .Max(x => x.Weight);
                    }

                    return new NextLoadViewModel
                    {
                        IsMax = isMax,
                        IsMin = isMin,
                        Weight = nextWeight
                    };
                }
            }

            return null!;
        }

        private void CreateExerciseLoad(int exerciseId, decimal load, string notes)
        {
            var newLoad = new ExerciseLoad
            {
                CurrentNotes = notes,
                ExerciseId = exerciseId,
                LogDate = DateTime.Now,
                CurrentLoad = load
            };

            _exerciseLoadRepository.Add(newLoad);
            _exerciseLoadRepository.Commit();
        }
    }
}
