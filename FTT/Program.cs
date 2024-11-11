using Microsoft.Extensions.DependencyInjection;

namespace FTT
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            
            Session.Instance.ServiceProvider = BuildServiceProvider();
            RegisteredServiceProvider.Instance.Install();

            Application.Run(new MainForm());
        }

        static ServiceProvider BuildServiceProvider()
        {
            var services = new ServiceCollection();
            Startup.ConfigureServices(services);

            return services.BuildServiceProvider();
        }
    }
}