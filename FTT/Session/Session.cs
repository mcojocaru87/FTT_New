using FTT.DbEntity;
using Microsoft.Extensions.DependencyInjection;

namespace FTT
{
    public class Session
    {
        private static Session? _instance;

        public ServiceProvider? ServiceProvider { get; set; }
        public int? ActiveWorkoutId { get; set; }
        public bool IsActiveWorkoutProgressMade { get; set; }
        public User? CurrentUser { get; set; }

        private Session() { }

        public static Session Instance
        {
            get
            {
                _instance ??= new Session();
                return _instance;
            }
        }
    }
}
