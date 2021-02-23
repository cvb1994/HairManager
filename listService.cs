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
    public partial class listService : Form
    {
        serviceDAO a = new serviceDAO();
        public listService()
        {
            InitializeComponent();
            dataGridView1.DataSource = a.getData();
            this.dataGridView1.Columns["ID"].Visible = false;
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.SelectedCells[0].OwningRow.Cells["ID"].Value.ToString());
            editService a = new editService(id);
            this.Hide();
            a.ShowDialog();
            this.Show();
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btImageShow_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.SelectedCells[0].OwningRow.Cells["ID"].Value.ToString());
            imageDisplay a = new imageDisplay(id);
            this.Hide();
            a.ShowDialog();
            this.Show();
        }
    }
}
