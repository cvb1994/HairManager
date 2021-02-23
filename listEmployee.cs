using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HairManager.DAO;

namespace HairManager
{
    public partial class listEmployee : Form
    {
        empDAO a = new empDAO();
        public listEmployee()
        {
            InitializeComponent();
            dataGridView1.DataSource = a.getEmp();

        }

        private void btDetail_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.SelectedCells[0].OwningRow.Cells["ID"].Value.ToString());
            empStatic a = new empStatic(id);
            this.Hide();
            a.ShowDialog();
            this.Show();
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.SelectedCells[0].OwningRow.Cells["ID"].Value.ToString());
            editEmp a = new editEmp(id);
            this.Hide();
            a.ShowDialog();
            this.Show();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.SelectedCells[0].OwningRow.Cells["ID"].Value.ToString());
            var confirmResult = MessageBox.Show("Bạn có chắc muốn xóa nhân viên.",
                                     "Xác Nhận Xóa",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                a.deleteEmp(id);
            }
            dataGridView1.DataSource = a.getEmp();
        }
    }
}
