using FTT.DataAccesss;
using FTT.DbDesign;
using FTT.Services;
using FTT.Services.Authentication;
using FTT.Services.ExerciseWLoad;
using FTT.Services.RepRange;
using FTT.Services.Track;
using FTT.Services.WorkoutTemplate;
using Microsoft.Extensions.DependencyInjection;

namespace FTT
{
    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IWorkoutService), typeof(WorkoutService));
            services.AddScoped(typeof(ITrackService), typeof(TrackService));
            services.AddScoped(typeof(IExerciseLoadService), typeof(ExerciseLoadService));
            services.AddScoped(typeof(IAuthenticationService), typeof(AuthenticationService));
            services.AddScoped(typeof(IRepRangeService), typeof(RepRangeService));
            services.AddScoped(typeof(IWorkoutTemplateService), typeof(WorkoutTemplateService));
        }
    }
}
