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
        public DbSet<ToolTimer> ToolTimers { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<EquipmentItem> EquipmentItems { get; set; }
        public DbSet<RepRangeInterval> RepRangeIntervals { get; set; }
        public DbSet<ProgressiveOverload> ProgressiveOverloads { get; set; }
        public DbSet<ProgressiveOverloadAudit> ProgressiveOverloadAudits { get; set; }
        public DbSet<ExerciseLoad> ExerciseLoads { get; set; }
        public DbSet<SlowProgressTrack> SlowProgressTracks { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dataSource = string.Empty;

#if DEBUG
            dataSource = "Data Source=C:\\FTT\\FTT_Test.db";
#else
            dataSource = "Data Source=C:\\FTT\\FTT.db";
#endif
            optionsBuilder.UseSqlite(dataSource);
        }
    }
}
