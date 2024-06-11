using FTT.DataAccesss;
using FTT.DbEntity;
using Microsoft.Extensions.DependencyInjection;

namespace FTT.UserControls.DataTables.EquipmentControls
{
    public partial class EquipmentForm : Form
    {
        private readonly IRepository<Equipment> _equipmentRepository;
        private readonly int _equipmentId;

        private Equipment _equipment = null!;

        public EquipmentForm(int equipmentId)
        {
            InitializeComponent();

            _equipmentRepository = Session.Instance.ServiceProvider.GetRequiredService<IRepository<Equipment>>();
            _equipmentId = equipmentId;

            LoadData();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void LoadData()
        {
            if (_equipmentId > 0)
            {
                var equipment = _equipmentRepository.GetById(_equipmentId);

                if (equipment != null)
                {
                    txtId.Text = equipment.Id.ToString();
                    txtName.Text = equipment.Name;
                    txtShortName.Text = equipment.ShortName;
                    rbIsDumbbell.Checked = equipment.IsDumbbell;
                    rbIsPlate.Checked = equipment.IsPlate;

                    _equipment = equipment;
                }
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (_equipmentId > 0)
            {
                _equipment.ShortName = txtShortName.Text;
                _equipment.Name = txtName.Text;
                _equipment.IsDumbbell = rbIsDumbbell.Checked;
                _equipment.IsPlate = rbIsPlate.Checked;

                _equipmentRepository.Update(_equipment);
                _equipmentRepository.Commit();

                MessageBox.Show($"Equipment has been successfully updated!", "Success", MessageBoxButtons.OK);
            }
            else
            {
                var newExercise = new Equipment
                {
                    Name = txtName.Text,
                    ShortName = txtShortName.Text,
                    IsDumbbell = rbIsDumbbell.Checked,
                    IsPlate = rbIsPlate.Checked
                };

                _equipmentRepository.Add(newExercise);
                _equipmentRepository.Commit();

                MessageBox.Show($"Equipment has been successfully created! Id: {newExercise.Id}", "Success", MessageBoxButtons.OK);
            }

            this.Dispose();
            this.Close();
        }
    }
}
