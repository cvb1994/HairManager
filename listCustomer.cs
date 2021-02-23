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
    public partial class listCustomer : Form
    {
        customerDAO obj = new customerDAO();

        public listCustomer()
        {
            InitializeComponent();
            DataTable dt = obj.getData();
            /*foreach (DataRow row in dt.Rows)
            {
                string s = string.Format("{0:#,##0.00}", row["Mức độ chi tiêu"]);
                row["Mức độ chi tiêu"] = s;
            }*/
            dataGridView1.DataSource = dt;
            this.dataGridView1.Columns["ID"].Visible = false;

        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.SelectedCells[0].OwningRow.Cells["ID"].Value.ToString());
            editCustomer a = new editCustomer(id);
            this.Hide();
            a.ShowDialog();
            this.Show();
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btListService_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.SelectedCells[0].OwningRow.Cells["ID"].Value.ToString());
            CustomerListService a = new CustomerListService(id);
            this.Hide();
            a.ShowDialog();
            this.Show();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void brSearch_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = obj.searchData(txtSearch.Text);
        }
    }
}
