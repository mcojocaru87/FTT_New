using FTT.DataAccesss;
using FTT.DbEntity;
using FTT.Services;
using FTT.ViewModels;

namespace FTT
{
    public partial class TimerForm : Form
    {
        private readonly IRepository<ToolTimer> _toolTimerRepository = RegisteredServiceProvider.Instance.ToolTimerRepository!;
        private readonly IWorkoutService _workoutService = RegisteredServiceProvider.Instance.WorkoutService!;
        private readonly bool _showExercises;

        private TimeSpan timeLeft;
        private ToolTimer toolTimer;
        private DateTime startTime;

        public TimerForm(bool showExercises = false)
        {
            InitializeComponent();

            _showExercises = showExercises;

            timer.Interval = 1000;
            currentTimeTimer.Interval = 1000;
            workoutTimeTimer.Interval = 1000;

            AutoStartTimer();
            StartWorkoutTimeTimer();
            StartCurrentTimeTimer();
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

        private void StartCurrentTimeTimer()
        {
            currentTimeTimer.Start();
        }

        private void StartWorkoutTimeTimer()
        {
            workoutTimeTimer.Start();
        }

        private ToolTimer? LoadTimerSettings()
        {
            return _toolTimerRepository?.GetAll().FirstOrDefault();
        }

        private void CloseForm()
        {
            this.Dispose();
            this.Close();

            currentTimeTimer.Stop();
        }

        private void UpdateTimeLabel()
        {
            lblTime.Text = timeLeft.ToString(@"hh\:mm\:ss");
        }

        private void UpdateCurrentTimeLabel()
        {
            lblCurrentTime.Text = DateTime.Now.ToString(@"HH\:mm\:ss");
        }

        private void UpdateWorkoutTimeLabel()
        {
            TimeSpan elapsedTime = DateTime.Now - startTime;
            lblWorkoutTime.Text = FormatElapsedTime(elapsedTime);
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

                    _toolTimerRepository?.Update(toolTimer);
                    _toolTimerRepository?.Commit();
                }
            }
        }

        private void SetupExercises()
        {
            if (_showExercises)
            {
                var exerciseRepository = RegisteredServiceProvider.Instance.ExerciseRepository;

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
                    var trackService = RegisteredServiceProvider.Instance.TrackService;
                    var exerciseNotes = trackService?.GetTrackingNotes((int)selectedExercise.ValueMember);

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

        private void currentTimeTimer_Tick(object sender, EventArgs e)
        {
            UpdateCurrentTimeLabel();
        }

        private void workoutTimeTimer_Tick(object sender, EventArgs e)
        {
            UpdateWorkoutTimeLabel();
        }

        private string FormatElapsedTime(TimeSpan elapsedTime)
        {
            return string.Format("{0:D2}:{1:D2}:{2:D2}",
                elapsedTime.Hours,
                elapsedTime.Minutes,
                elapsedTime.Seconds);
        }

        private void TimerForm_Load(object sender, EventArgs e)
        {
            if (Session.Instance.ActiveWorkoutId != null && Session.Instance.ActiveWorkoutId > 0)
            {
                var activeWorkout = _workoutService?.GetWorkoutById((int)Session.Instance.ActiveWorkoutId);

                if (activeWorkout != null)
                {
                    startTime = activeWorkout.Workout.WorkoutDate;
                }
            }
        }

        private void Add30SecButton_Click(object sender, EventArgs e)
        {
            if (timeLeft.TotalSeconds > 0)
            {
                timeLeft = timeLeft.Add(TimeSpan.FromSeconds(30));
                UpdateTimeLabel();
            }
        }

        private void Take30SecButton_Click(object sender, EventArgs e)
        {
            if (timeLeft.TotalSeconds > 30)
            {
                timeLeft = timeLeft.Subtract(TimeSpan.FromSeconds(30));
                UpdateTimeLabel();
            }
        }
    }
}
