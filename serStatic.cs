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
    public partial class serStatic : Form
    {
        serviceDAO a = new serviceDAO();
        public serStatic()
        {
            InitializeComponent();
            this.monthCalendar1.Hide();
            DateTime today = DateTime.Today;
            this.lbDateDisplay.Text = today.ToString("dd-MM-yyyy");
            loadData(a.getByDay(today));
            dataCal(a.getByDay(today));
            this.dataGridView1.Columns["ID"].Visible = false;
            this.dataGridView1.Columns["Thanh toán"].Visible = false;

        }

        public void loadData(DataTable dt)
        {
            dataGridView1.DataSource = dt;
        }

        public void dataCal(DataTable dt)
        {
            int totalRevenue = 0;
            foreach(DataRow row in dt.Rows)
            {
                int revenue = Convert.ToInt32(row["Thanh toán"].ToString());
                totalRevenue += revenue;
            }
            txtRevenue.Text = totalRevenue.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.monthCalendar1.Show();
        }


        private void monthCalendar1_DateSelected_1(object sender, DateRangeEventArgs e)
        {
            this.monthCalendar1.Hide();
            this.lbDateDisplay.Text = monthCalendar1.SelectionRange.Start.ToString();
            loadData(a.getByDay(monthCalendar1.SelectionRange.Start));
            dataCal(a.getByDay(monthCalendar1.SelectionRange.Start));
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
