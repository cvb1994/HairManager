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
    
    public partial class addEmployee : Form
    {
        empDAO a = new empDAO();

        public addEmployee()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cus_insert_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text;
                int salary = convertText(txtBaseSalary.Text);
                int kpi = Convert.ToInt32(txtKPI.Text);

                a.addEmp(name, salary, kpi);
                MessageBox.Show("Thêm mới nhân viên thành công.");
                txtName.Clear();
                txtBaseSalary.Clear();
                txtKPI.Clear();

            } catch
            {
                MessageBox.Show("Vui lòng thử lại.");
            }


        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public int convertText(string str)
        {
            string s = str.Replace(",", "");
            int a = Convert.ToInt32(s);

            return a;
        }

        private void txtBaseSalary_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBaseSalary.Text))
            {
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                int valueBefore = Int32.Parse(txtBaseSalary.Text, System.Globalization.NumberStyles.AllowThousands);
                txtBaseSalary.Text = String.Format(culture, "{0:N0}", valueBefore);
                txtBaseSalary.Select(txtBaseSalary.Text.Length, 0);
            }
        }
    }
}
