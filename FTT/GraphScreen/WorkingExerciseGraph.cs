using FTT.ViewModels;
using System.Windows.Forms.DataVisualization.Charting;

namespace FTT.GraphScreen
{
    public partial class WorkingExerciseGraph : Form
    {
        private readonly List<GraphViewModel> _dataPoints;

        public WorkingExerciseGraph(List<GraphViewModel> dataPoints)
        {
            InitializeComponent();

            _dataPoints = dataPoints;

            LoadChartData();
        }

        private void LoadChartData()
        {
            ConfigureChart();
        }

        private void ConfigureChart()
        {
            Chart chart = new Chart();
            chart.Dock = DockStyle.Fill;
            Controls.Add(chart);

            ChartArea chartArea = new ChartArea();
            chart.ChartAreas.Add(chartArea);

            Series series = new Series
            {
                Name = "Volume",
                Color = Color.Blue,
                IsVisibleInLegend = true,
                IsXValueIndexed = true,
                ChartType = SeriesChartType.Line
            };

            chart.Series.Add(series);

            foreach (var dataPoint in _dataPoints)
            {
                series.Points.AddXY(dataPoint.Date, dataPoint.Volume);
            }

            chartArea.AxisX.LabelStyle.Format = "MMM dd, yyyy";
            chartArea.AxisX.IntervalType = DateTimeIntervalType.Days;
            chartArea.AxisX.Interval = 1;
            chartArea.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
        }
    }
}
