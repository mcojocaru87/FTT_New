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

            SplashScreen splash = new();
            splash.Show();
            splash.Refresh();

            // Simulate some loading tasks

            for (int i = 0; i <= 100; i++)
            {
                splash.Invoke(new Action(() => splash.progressBar.Value = i));
                Thread.Sleep(20); // Simulate loading
            }

            splash.Close();

            Session.Instance.ServiceProvider = BuildServiceProvider();

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