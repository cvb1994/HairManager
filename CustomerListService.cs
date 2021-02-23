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
    public partial class CustomerListService : Form
    {
        serviceDAO a = new serviceDAO();
        customerDAO b = new customerDAO();

        public CustomerListService(int id)
        {
            InitializeComponent();
            khachhang obj = b.getDetail(id);
            this.lbDisplayName.Text = obj.CustomerName;
            this.lbDisplayPhone.Text = obj.CustomerPhone;
            dataGridView1.DataSource = a.getCustomerData(id);
            this.dataGridView1.Columns["ID"].Visible = false;
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btEditService_Click(object sender, EventArgs e)
        {
            int serviceid = Convert.ToInt32(dataGridView1.SelectedCells[0].OwningRow.Cells["ID"].Value.ToString());
            editService a = new editService(serviceid);
            this.Hide();
            a.ShowDialog();
            this.Show();
        }
    }
}
