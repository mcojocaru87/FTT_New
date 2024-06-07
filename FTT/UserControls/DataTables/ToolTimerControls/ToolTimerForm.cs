using FTT.DataAccesss;
using FTT.DbEntity;
using FTT.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace FTT.UserControls.DataTables.ToolTimerControls
{
    public partial class ToolTimerForm : Form
    {
        private readonly IRepository<ToolTimer> _toolTimerRepository;
        private readonly int _toolTimerId = 0;

        private ToolTimer _toolTimer = null!;

        public ToolTimerForm(int toolTimerId)
        {
            InitializeComponent();

            _toolTimerRepository = Session.Instance.ServiceProvider.GetRequiredService<IRepository<ToolTimer>>();
            _toolTimerId = toolTimerId;

            LoadTimerData();
            LoadData();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (_toolTimerId > 0)
            {
                _toolTimer.Minutes = (int)cbMinutes.SelectedValue;
                _toolTimer.Seconds = (int)cbSeconds.SelectedValue;
                _toolTimer.Hours = (int)cbHours.SelectedValue;
                _toolTimer.IsDisplayed = (int)cbDisplay.SelectedValue == 1;

                _toolTimerRepository.Update(_toolTimer);
                _toolTimerRepository.Commit();

                MessageBox.Show($"Timer has been successfully updated!", "Success", MessageBoxButtons.OK);
            }
            else
            {
                var newToolTimer = new ToolTimer
                {
                    Hours = (int)cbHours.SelectedValue,
                    Minutes = (int)cbMinutes.SelectedValue,
                    Seconds = (int)cbSeconds.SelectedValue,
                    IsDisplayed = (int)cbDisplay.SelectedValue == 1
                };

                _toolTimerRepository.Add(newToolTimer);
                _toolTimerRepository.Commit();

                MessageBox.Show($"Timer has been successfully created! Id: {newToolTimer.Id}", "Success", MessageBoxButtons.OK);
            }

            this.Dispose();
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void LoadData()
        {
            if (_toolTimerId > 0)
            {
                var toolTimer = _toolTimerRepository.GetById(_toolTimerId);

                if (toolTimer != null)
                {
                    txtId.Text = toolTimer.Id.ToString();
                    cbHours.SelectedValue = toolTimer.Hours;
                    cbMinutes.SelectedValue = toolTimer.Minutes;
                    cbSeconds.SelectedValue = toolTimer.Seconds;
                    cbDisplay.SelectedValue = toolTimer.IsDisplayed ? 1 : 0;

                    _toolTimer = toolTimer;
                }
            }
        }

        private void LoadTimerData()
        {
            List<ComboBoxViewModel> minData = [];
            List<ComboBoxViewModel> secData = [];
            List<ComboBoxViewModel> hrData = [];

            for (int i = 0; i <= 59; i++)
            {
                minData.Add(new ComboBoxViewModel(i, i.ToString()));
                secData.Add(new ComboBoxViewModel(i, i.ToString()));
            }

            for (int i = 0; i <= 23; i++)
            {
                hrData.Add(new ComboBoxViewModel(i, i.ToString()));
            }

            cbMinutes.DataSource = minData;
            cbSeconds.DataSource = secData;
            cbHours.DataSource = hrData;

            cbMinutes.ValueMember = "ValueMember";
            cbMinutes.DisplayMember = "DisplayMember";

            cbSeconds.ValueMember = "ValueMember";
            cbSeconds.DisplayMember = "DisplayMember";

            cbHours.ValueMember = "ValueMember";
            cbHours.DisplayMember = "DisplayMember";

            List<ComboBoxViewModel> displayData = [
                new(0, "No"),
                new(1, "Yes")
            ];

            cbDisplay.DataSource = displayData;

            cbDisplay.ValueMember = "ValueMember";
            cbDisplay.DisplayMember = "DisplayMember";
        }
    }
}
