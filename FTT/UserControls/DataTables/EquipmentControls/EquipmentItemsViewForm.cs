using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTT.UserControls.DataTables.EquipmentControls
{
    public partial class EquipmentItemsViewForm : Form
    {
        public EquipmentItemsViewForm()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void dgItems_SelectionChanged(object sender, EventArgs e)
        {

        }
    }
}
