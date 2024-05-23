using FTT.DataAccesss;
using FTT.DbEntity;
using FTT.Enums;
using Microsoft.Extensions.DependencyInjection;

namespace FTT
{
    public partial class CleanupData : Form
    {
        private readonly IRepository<WorkingExercise> _workingExerciseRepository;
        private readonly IRepository<WorkingExerciseSet> _workingExerciseSetRepository;
        private readonly IRepository<Workout> _workoutRepository;
        private readonly IRepository<WorkoutItem> _workoutItemRepository;

        private int cleanedUpItems = 0;

        public CleanupData()
        {
            InitializeComponent();

            _workingExerciseRepository = Session.Instance.ServiceProvider.GetRequiredService<IRepository<WorkingExercise>>();
            _workingExerciseSetRepository = Session.Instance.ServiceProvider.GetRequiredService<IRepository<WorkingExerciseSet>>();
            _workoutRepository = Session.Instance.ServiceProvider.GetRequiredService<IRepository<Workout>>();
            _workoutItemRepository = Session.Instance.ServiceProvider.GetRequiredService<IRepository<WorkoutItem>>();
        }

        public void CleanUp()
        {
            RemoveEmptyWorkouts();
            RemoveEmptyWorkingExercises();

            if (cleanedUpItems > 0)
            {
                MessageBox.Show($"There was/were {cleanedUpItems} item(s) removed!");
            }
            else
            {
                MessageBox.Show("Congrats! No items to be removed!");
            }

            this.Close();
        }

        private void RemoveEmptyWorkouts()
        {
            var workouts = _workoutRepository.GetAll();

            foreach (var workout in workouts)
            {
                var workoutItems = _workoutItemRepository.Find(x => x.WorkoutId == workout.Id);

                if (!workoutItems.Any())
                {
                    cleanedUpItems++;

                    _workoutRepository.Delete(workout);
                }
            }

            _workoutRepository.Commit();
        }

        private void RemoveEmptyWorkingExercises()
        {
            var workingExercises = _workingExerciseRepository.GetAll();

            foreach (var workingExercise in workingExercises)
            {
                var sets = _workingExerciseSetRepository.Find(x => x.WorkingExerciseId == workingExercise.Id);

                if (!sets.Any())
                {
                    cleanedUpItems++;

                    _workingExerciseRepository.Delete(workingExercise);
                }
            }

            _workingExerciseRepository.Commit();
        }

        private void SimulateLoading()
        {
            for (int i = 0; i <= 50; i++)
            {
                progressBar.Value = i;
                Thread.Sleep(10); // Simulate loading
            }

            CleanUp();

            for (int i = 51; i <= 100; i++)
            {
                progressBar.Value = i;
                Thread.Sleep(10); // Simulate loading
            }

            this.Close();
        }

        private void CleanupData_Shown(object sender, EventArgs e)
        {
            SimulateLoading();
        }
    }
}
