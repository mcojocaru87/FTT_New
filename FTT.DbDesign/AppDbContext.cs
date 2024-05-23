namespace FTT.DbDesign
{
    using FTT.DbEntity;
    using FTT.Enums;
    using Microsoft.EntityFrameworkCore;

    public class AppDbContext : DbContext
    {
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<WorkingExercise> WorkingExercises { get; set; }
        public DbSet<WorkingExerciseSet> WorkingExerciseSets { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<WorkoutItem> WorkoutItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:\\FTT\\FTT.db");
        }
    }
}
