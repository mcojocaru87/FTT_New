using FTT.DataAccesss;
using FTT.DbEntity;
using FTT.Services.WorkoutTemplate;
using FTT.ViewModels;

namespace FTT
{
    public class WorkoutTemplateForm : Form
    {
        private readonly IWorkoutTemplateService _templateService;
        private readonly IRepository<Exercise> _exerciseRepository;

        private readonly ListBox _templatesList = new();
        private readonly TextBox _templateName = new();
        private readonly CheckedListBox _exerciseCheckList = new();
        private readonly Button _newButton = new();
        private readonly Button _saveButton = new();
        private readonly Button _deleteButton = new();

        private int? _activeTemplateId;

        public WorkoutTemplateForm()
        {
            _templateService = RegisteredServiceProvider.Instance.WorkoutTemplateService!;
            _exerciseRepository = RegisteredServiceProvider.Instance.ExerciseRepository!;

            Text = "Workout Templates";
            StartPosition = FormStartPosition.CenterParent;
            Width = 760;
            Height = 450;

            InitializeControls();
            LoadExercises();
            LoadTemplates();
        }

        private void InitializeControls()
        {
            var listLabel = new Label { Text = "Templates", Left = 10, Top = 10, Width = 120 };
            _templatesList.Left = 10;
            _templatesList.Top = 30;
            _templatesList.Width = 250;
            _templatesList.Height = 330;
            _templatesList.SelectedIndexChanged += TemplatesList_SelectedIndexChanged;

            var nameLabel = new Label { Text = "Template name", Left = 280, Top = 10, Width = 200 };
            _templateName.Left = 280;
            _templateName.Top = 30;
            _templateName.Width = 450;

            var exerciseLabel = new Label { Text = "Exercises included in this template", Left = 280, Top = 65, Width = 250 };
            _exerciseCheckList.Left = 280;
            _exerciseCheckList.Top = 85;
            _exerciseCheckList.Width = 450;
            _exerciseCheckList.Height = 275;

            _newButton.Text = "New";
            _newButton.Left = 280;
            _newButton.Top = 370;
            _newButton.Click += (_, _) => ResetTemplateEditor();

            _saveButton.Text = "Save";
            _saveButton.Left = 360;
            _saveButton.Top = 370;
            _saveButton.Click += SaveButton_Click;

            _deleteButton.Text = "Delete";
            _deleteButton.Left = 440;
            _deleteButton.Top = 370;
            _deleteButton.Click += DeleteButton_Click;

            Controls.AddRange([listLabel, _templatesList, nameLabel, _templateName, exerciseLabel, _exerciseCheckList, _newButton, _saveButton, _deleteButton]);
        }

        private void LoadExercises()
        {
            var exercises = _exerciseRepository.GetAll()
                .OrderBy(x => x.Category)
                .ThenBy(x => x.Name)
                .Select(x => new ComboBoxViewModel(x.Id, $"{x.Category} - {x.Name}"))
                .ToList();

            _exerciseCheckList.Items.Clear();

            foreach (var exercise in exercises)
            {
                _exerciseCheckList.Items.Add(exercise, false);
            }

            _exerciseCheckList.DisplayMember = nameof(ComboBoxViewModel.DisplayMember);
        }

        private void LoadTemplates()
        {
            _templatesList.DataSource = null;
            var templates = _templateService.GetAllTemplates();
            _templatesList.DataSource = templates;
            _templatesList.DisplayMember = nameof(WorkoutTemplate.Name);
            _templatesList.ValueMember = nameof(WorkoutTemplate.Id);
        }

        private void TemplatesList_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (_templatesList.SelectedItem is not WorkoutTemplate selected)
            {
                return;
            }

            var template = _templateService.GetTemplateById(selected.Id);

            if (template == null)
            {
                return;
            }

            _activeTemplateId = template.Id;
            _templateName.Text = template.Name;

            var selectedExerciseIds = template.Exercises.Select(x => x.ExerciseId).ToHashSet();
            for (var i = 0; i < _exerciseCheckList.Items.Count; i++)
            {
                if (_exerciseCheckList.Items[i] is ComboBoxViewModel item && item.ValueMember is int exerciseId)
                {
                    _exerciseCheckList.SetItemChecked(i, selectedExerciseIds.Contains(exerciseId));
                }
            }
        }

        private void ResetTemplateEditor()
        {
            _activeTemplateId = null;
            _templateName.Text = string.Empty;
            for (var i = 0; i < _exerciseCheckList.Items.Count; i++)
            {
                _exerciseCheckList.SetItemChecked(i, false);
            }
            _templatesList.ClearSelected();
        }

        private void SaveButton_Click(object? sender, EventArgs e)
        {
            var templateName = _templateName.Text.Trim();
            if (string.IsNullOrWhiteSpace(templateName))
            {
                MessageBox.Show("Please enter a template name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedExerciseIds = _exerciseCheckList.CheckedItems
                .OfType<ComboBoxViewModel>()
                .Where(x => x.ValueMember is int)
                .Select(x => (int)x.ValueMember!)
                .ToList();

            if (selectedExerciseIds.Count == 0)
            {
                MessageBox.Show("Please select at least one exercise.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _templateService.SaveTemplate(_activeTemplateId, templateName, selectedExerciseIds);

            LoadTemplates();
            MessageBox.Show("Template saved successfully.", "Workout Templates", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DeleteButton_Click(object? sender, EventArgs e)
        {
            if (_activeTemplateId == null)
            {
                return;
            }

            var answer = MessageBox.Show("Delete selected template?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.No)
            {
                return;
            }

            _templateService.DeleteTemplate(_activeTemplateId.Value);
            LoadTemplates();
            ResetTemplateEditor();
        }
    }
}
