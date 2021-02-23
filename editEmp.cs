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
    public partial class editEmp : Form
    {
        empDAO a = new empDAO();
        int idEmp;
        public editEmp(int id)
        {
            InitializeComponent();
            idEmp = id;
            nhanvien obj = a.getDetail(id);
            txtEmpName.Text = obj.employeeName;
            txtBaseSalary.Text = obj.base_salary.ToString();
            txtKPI.Text = obj.kpi.ToString();

        }

        private void btSave_Click(object sender, EventArgs e)
        {
            string name = txtEmpName.Text;
            int baseSalary = Convert.ToInt32(txtBaseSalary.Text);
            int kpi = Convert.ToInt32(txtKPI.Text);
            a.updateEmp(idEmp, name, baseSalary, kpi);
            MessageBox.Show("Lưu thay đổi thành công.");
            foreach(var txt in this.Controls.OfType<TextBox>())
            {
                txt.Clear();
            }
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
