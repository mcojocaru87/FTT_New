using FTT.DbEntity;
using Microsoft.Extensions.DependencyInjection;

namespace FTT
{
    public class Session
    {
        private static Session _instance;

        public ServiceProvider ServiceProvider { get; set; }
        public Setting? Settings { get; set; }
        public int? ActiveWorkoutId { get; set; }

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
