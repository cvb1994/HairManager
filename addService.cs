using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HairManager.DAO;

namespace HairManager
{
    public partial class addService : Form
    {
        customerDAO a = new customerDAO();
        empDAO b = new empDAO();
        serviceDAO c = new serviceDAO();

        public addService()
        {
            InitializeComponent();
            
            for(int i = 0; i < b.getEmp().Rows.Count; i++)
            {
                string text = b.getEmp().Rows[i]["ID"].ToString() + "- " + b.getEmp().Rows[i]["Tên nhân viên"].ToString();
                this.txtEmp.Items.Add(text);
            }
        }

        public void AddBinding()
        {
            lbNameDisplay.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "Tên khách hàng"));
            lbPhoneDisplay.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "Điện thoại"));
        }

        public void clearBinding()
        {
            lbNameDisplay.DataBindings.Clear();
            lbPhoneDisplay.DataBindings.Clear();
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            clearBinding();
            dataGridView1.DataSource = a.searchData(txtSearch.Text);
            this.dataGridView1.Columns["ID"].Visible = false;
            this.dataGridView1.Columns["Địa chỉ"].Visible = false;
            this.dataGridView1.Columns["Giới tính"].Visible = false;
            this.dataGridView1.Columns["Cấp độ"].Visible = false;
            this.dataGridView1.Columns["Mức độ chi tiêu"].Visible = false;


            AddBinding();
        }

        List<string> imageList = new List<string>();


        private void btInsert_Click(object sender, EventArgs e)
        {
            try
            {
                int cus_id = 0;
                cus_id = Convert.ToInt32(dataGridView1.SelectedCells[0].OwningRow.Cells["ID"].Value.ToString());
                string name = txtService.Text;
                int price = convertText(txtPrice.Text);
                string des = txtDescribe.Text;
                int count = txtEmp.Text.IndexOf("-");
                int emp_id = Convert.ToInt32(txtEmp.Text.Substring(0, count));

                dichvu bill = c.addService(name, price, des, cus_id, emp_id);
                int billID = bill.ServiceID;
                billExport obj = new billExport(billID);
                obj.ShowDialog();
                txtService.Clear();
                txtPrice.Clear();
                txtDescribe.Clear();
            } catch
            {
                MessageBox.Show("Vui lòng thử lại.");
            }

        }

        private void btBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPrice.Text))
            {
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                int valueBefore = Int32.Parse(txtPrice.Text, System.Globalization.NumberStyles.AllowThousands);
                txtPrice.Text = String.Format(culture, "{0:N0}", valueBefore);
                txtPrice.Select(txtPrice.Text.Length, 0);
            }
        }

        public int convertText(string str)
        {
            string s = str.Replace(",", "");
            int a = Convert.ToInt32(s);

            return a;
        }
    }
}
