using FTT.DataAccesss;
using FTT.DbEntity;
using FTT.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace FTT.UserControls.DataTables.RepRangeIntervalControls
{
    public partial class RepRangeIntervalForm : Form
    {
        private readonly IRepository<RepRangeInterval> _repRangeIntervalRepository;
        private readonly IRepository<Exercise> _exerciseRepository;
        private readonly int _repRangeIntervalId = 0;

        private RepRangeInterval _repRangeInterval = null!;

        public RepRangeIntervalForm(int repRangeIntervalId)
        {
            InitializeComponent();

            _repRangeIntervalRepository = Session.Instance.ServiceProvider.GetRequiredService<IRepository<RepRangeInterval>>();
            _exerciseRepository = Session.Instance.ServiceProvider.GetRequiredService<IRepository<Exercise>>();
            _repRangeIntervalId = repRangeIntervalId;

            LoadData();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (_repRangeIntervalId > 0)
            {
                _repRangeInterval.MinReps = int.Parse(txtMinReps.Text);
                _repRangeInterval.MaxReps = int.Parse(txtMaxReps.Text);
                
                _repRangeIntervalRepository.Update(_repRangeInterval);
                _repRangeIntervalRepository.Commit();

                MessageBox.Show($"Interval has been successfully updated!", "Success", MessageBoxButtons.OK);
            }
            else
            {
                var newRepRangeInterval = new RepRangeInterval
                {
                    MinReps = int.Parse(txtMinReps.Text),
                    MaxReps = int.Parse(txtMaxReps.Text),
                };               

                _repRangeIntervalRepository.Add(newRepRangeInterval);
                _repRangeIntervalRepository.Commit();

                MessageBox.Show($"Timer has been successfully created! Id: {newRepRangeInterval.Id}", "Success", MessageBoxButtons.OK);
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
            if (_repRangeIntervalId > 0)
            {
                var repRangeInterval = _repRangeIntervalRepository.GetById(_repRangeIntervalId);

                if (repRangeInterval != null)
                {
                    txtId.Text = repRangeInterval.Id.ToString();
                    txtMinReps.Text = repRangeInterval.MinReps.ToString();
                    txtMaxReps.Text = repRangeInterval.MaxReps.ToString();

                    _repRangeInterval = repRangeInterval;
                }
            }
        }
    }
}
