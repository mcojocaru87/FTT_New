using FTT.DataAccesss;
using FTT.DbEntity;
using FTT.Services;
using FTT.Services.Authentication;
using FTT.Services.ExerciseWLoad;
using FTT.Services.RepRange;
using FTT.Services.Track;
using FTT.Services.WorkoutTemplate;
using Microsoft.Extensions.DependencyInjection;

namespace FTT
{
    public class RegisteredServiceProvider
    {
        private static RegisteredServiceProvider? _instance;

        private RegisteredServiceProvider()
        {

        }

        public IWorkoutService? WorkoutService { get; set; }
        public ITrackService? TrackService { get; set; }
        public IExerciseLoadService? ExerciseLoadService { get; set; }
        public IAuthenticationService? AuthenticationService { get; set; }
        public IRepository<Exercise>? ExerciseRepository { get; set; }
        public IRepository<Setting>? ExerciseSettingsRepository { get; set; }
        public IRepository<ToolTimer>? ToolTimerRepository { get; set; }
        public IRepository<RepRangeInterval>? IntervalRepository { get; set; }
        public IRepository<User>? UserRepository { get; set; }
        public IRepRangeService? RepRangeService { get; set; }
        public IWorkoutTemplateService? WorkoutTemplateService { get; set; }

        public static RegisteredServiceProvider Instance
        {
            get
            {
                _instance ??= new RegisteredServiceProvider();
                return _instance;
            }
        }

        public void Install()
        {
            WorkoutService = Session.Instance.ServiceProvider?.GetRequiredService<IWorkoutService>();
            TrackService = Session.Instance.ServiceProvider?.GetRequiredService<ITrackService>();
            ExerciseLoadService = Session.Instance.ServiceProvider?.GetRequiredService<IExerciseLoadService>();
            AuthenticationService = Session.Instance.ServiceProvider?.GetRequiredService<IAuthenticationService>();
            ExerciseRepository = Session.Instance.ServiceProvider?.GetRequiredService<IRepository<Exercise>>();
            ExerciseSettingsRepository = Session.Instance.ServiceProvider?.GetRequiredService<IRepository<Setting>>();
            ToolTimerRepository = Session.Instance.ServiceProvider?.GetRequiredService<IRepository<ToolTimer>>();
            IntervalRepository = Session.Instance.ServiceProvider?.GetRequiredService<IRepository<RepRangeInterval>>();
            UserRepository = Session.Instance.ServiceProvider?.GetRequiredService<IRepository<User>>();
            RepRangeService = Session.Instance.ServiceProvider?.GetRequiredService<IRepRangeService>();
            WorkoutTemplateService = Session.Instance.ServiceProvider?.GetRequiredService<IWorkoutTemplateService>();
        }
    }
}
