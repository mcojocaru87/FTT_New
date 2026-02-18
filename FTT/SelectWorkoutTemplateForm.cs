using FTT.DbEntity;
using FTT.Services.WorkoutTemplate;

namespace FTT
{
    public class SelectWorkoutTemplateForm : Form
    {
        private readonly IWorkoutTemplateService _templateService;
        private readonly ComboBox _templates = new();

        public int? SelectedTemplateId { get; private set; }

        public SelectWorkoutTemplateForm()
        {
            _templateService = RegisteredServiceProvider.Instance.WorkoutTemplateService!;

            Text = "Choose Workout Template";
            StartPosition = FormStartPosition.CenterParent;
            Width = 430;
            Height = 180;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;

            var label = new Label { Left = 15, Top = 20, Width = 250, Text = "Template (optional):" };
            _templates.Left = 15;
            _templates.Top = 45;
            _templates.Width = 380;
            _templates.DropDownStyle = ComboBoxStyle.DropDownList;

            var startButton = new Button { Text = "Start Workout", Left = 285, Top = 85, Width = 110 };
            startButton.Click += StartButton_Click;

            var manageButton = new Button { Text = "Manage Templates", Left = 155, Top = 85, Width = 120 };
            manageButton.Click += ManageButton_Click;

            Controls.AddRange([label, _templates, startButton, manageButton]);

            LoadTemplates();
        }

        private void LoadTemplates()
        {
            var templates = _templateService.GetAllTemplates();
            templates.Insert(0, new WorkoutTemplate { Id = 0, Name = "No template (all exercises)" });

            _templates.DataSource = templates;
            _templates.DisplayMember = nameof(WorkoutTemplate.Name);
            _templates.ValueMember = nameof(WorkoutTemplate.Id);
            _templates.SelectedIndex = 0;
        }

        private void ManageButton_Click(object? sender, EventArgs e)
        {
            using var form = new WorkoutTemplateForm();
            form.ShowDialog(this);
            LoadTemplates();
        }

        private void StartButton_Click(object? sender, EventArgs e)
        {
            if (_templates.SelectedItem is WorkoutTemplate template)
            {
                SelectedTemplateId = template.Id == 0 ? null : template.Id;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
