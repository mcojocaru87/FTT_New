using FTT.DataAccesss;
using FTT.DbEntity;
using Microsoft.Extensions.DependencyInjection;

namespace FTT
{
    public partial class TimerForm : Form
    {
        private readonly IRepository<ToolTimer> _toolTimerRepository;

        private TimeSpan timeLeft;
        private ToolTimer toolTimer;

        public TimerForm()
        {
            InitializeComponent();

            _toolTimerRepository = Session.Instance.ServiceProvider.GetRequiredService<IRepository<ToolTimer>>();

            timer.Interval = 1000;

            AutoStartTimer();
        }

        private void AutoStartTimer()
        {
            var timerSettings = LoadTimerSettings();

            if (timerSettings != null)
            {
                toolTimer = timerSettings;

                timeLeft = new TimeSpan(timerSettings.Hours, timerSettings.Minutes, timerSettings.Seconds);
                UpdateTimeLabel();
                timer.Start();
            }
            else
            {
                CloseForm();
            }
        }

        private ToolTimer? LoadTimerSettings()
        {
            return _toolTimerRepository.GetAll().FirstOrDefault();
        }

        private void CloseForm()
        {
            this.Dispose();
            this.Close();
        }

        private void UpdateTimeLabel()
        {
            lblTime.Text = timeLeft.ToString(@"hh\:mm\:ss");
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (timeLeft.TotalSeconds > 0)
            {
                timeLeft = timeLeft.Subtract(TimeSpan.FromSeconds(1));
                UpdateTimeLabel();
            }
            else
            {
                timer.Stop();
                CloseForm();
            }
        }

        private void lblSkip_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            timer.Stop();
            CloseForm();
        }

        private void chkDoNotShow_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDoNotShow.Checked)
            {
                if (toolTimer != null)
                {
                    toolTimer.IsDisplayed = false;

                    _toolTimerRepository.Update(toolTimer);
                    _toolTimerRepository.Commit();
                }
            }
        }
    }
}
