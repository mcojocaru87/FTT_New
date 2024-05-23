using FTT.DataAccesss;
using FTT.DbDesign;
using FTT.Services;
using FTT.Services.Track;
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
        }
    }
}
