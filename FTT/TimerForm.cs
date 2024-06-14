using FTT.DataAccesss;
using FTT.DbEntity;
using FTT.Services.Track;
using FTT.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace FTT
{
    public partial class TimerForm : Form
    {
        private readonly IRepository<ToolTimer> _toolTimerRepository;
        private readonly bool _showExercises;

        private TimeSpan timeLeft;
        private ToolTimer toolTimer;

        public TimerForm(bool showExercises = false)
        {
            InitializeComponent();

            _toolTimerRepository = Session.Instance.ServiceProvider.GetRequiredService<IRepository<ToolTimer>>();
            _showExercises = showExercises;

            timer.Interval = 1000;
            
            AutoStartTimer();
            SetupExercises();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                lblSkip_LinkClicked(this, null!);

                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
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

        private void SetupExercises()
        {
            if (_showExercises)
            {
                var exerciseRepository = Session.Instance.ServiceProvider.GetRequiredService<IRepository<Exercise>>();

                if (exerciseRepository != null)
                {
                    var exercises = exerciseRepository.GetAll()
                        .OrderBy(x => x.Category)
                        .Select(x => new ComboBoxViewModel(x.Id, $"{x.Category} - {x.Name}"))
                        .ToList();

                    exercises.Add(new(0, string.Empty));

                    cbExercises.DataSource = exercises;
                    cbExercises.DisplayMember = "DisplayMember";
                    cbExercises.ValueMember = "ValueMember";
                    cbExercises.SelectedValue = 0;
                    cbExercises.Visible = true;
                }
            }
        }

        private void cbExercises_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbExercises.SelectedItem is ComboBoxViewModel selectedExercise && selectedExercise.ValueMember != null)
            {
                if ((int)selectedExercise.ValueMember > 0)
                {
                    var trackService = Session.Instance.ServiceProvider.GetRequiredService<ITrackService>();
                    var exerciseNotes = trackService.GetTrackingNotes((int)selectedExercise.ValueMember);

                    if (exerciseNotes != null)
                    {
                        txtNotes.Text = exerciseNotes.Notes;
                        txtNotes.Visible = true;
                    }
                }
                else
                {
                    txtNotes.Clear();
                    txtNotes.Visible = false;
                }
            }
            else
            {
                txtNotes.Clear();
                txtNotes.Visible = false;
            }
        }
    }
}
