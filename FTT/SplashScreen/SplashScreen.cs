using System.Reflection;

namespace FTT
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
            DisplayVersion();
        }

        private void DisplayVersion()
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version;

            lblVersion.Text = $"Ver.: {version}";
        }
    }
}
