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
    public partial class empStatic : Form
    {
        empDAO a = new empDAO();
        int empId;
        public empStatic(int id)
        {
            InitializeComponent();
            empId = id;
            loadData(a.getStatic(empId, 0));
            dataBinding(a.getDetail(id).base_salary, kpiCal(a.getStatic(empId, 0)));
            lbNameDisplay.Text = a.getDetail(id).employeeName;
            this.dataGridView1.Columns["KPI"].Visible = false;
        }

        public void dataBinding(int basesalary ,int kpi)
        {
            txtBaseSalary.Text = basesalary.ToString();
            txtKPI.Text = kpi.ToString();
            txtSumSalary.Text = (basesalary + kpi).ToString();
        }

        private void txtTimeSearch_SelectedValueChanged(object sender, EventArgs e)
        {
            if(txtTimeSearch.SelectedIndex == 0)
            {
                loadData(a.getStatic(empId, 0));
                dataBinding(a.getDetail(empId).base_salary, kpiCal(a.getStatic(empId, 0)));
            } else if(txtTimeSearch.SelectedIndex == 1)
            {
                loadData(a.getStatic(empId, 1));
                dataBinding(a.getDetail(empId).base_salary, kpiCal(a.getStatic(empId, 1)));
            } else if(txtTimeSearch.SelectedIndex == 2)
            {
                loadData(a.getStatic(empId, 2));
                dataBinding(a.getDetail(empId).base_salary, kpiCal(a.getStatic(empId, 2)));
            }
        }

        public void loadData(DataTable dt)
        {
            dataGridView1.DataSource = dt;
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public int kpiCal(DataTable dt)
        {
            int sum = 0;
            foreach(DataRow row in dt.Rows)
            {
                int kpi = Convert.ToInt32(row["KPI"].ToString());
                sum += kpi;
            }

            return sum;
        }

        
    }
}
