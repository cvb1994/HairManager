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
    public partial class editCustomer : Form
    {
        customerDAO obj = new customerDAO();
        

        public editCustomer(int id)
        {
            InitializeComponent();
            khachhang kh = obj.getDetail(id);
            if (kh.CustomerGender == "Nam")
            {
                this.male.Checked = true;
            }
            else
            {
                this.female.Checked = true;
            }
            this.txtLevel.Text = kh.CustomerLevel;
            this.lbID.Text = kh.CustomerID.ToString();
            this.txtAddress.Text = kh.CustomerAddress;
            this.txtPhone.Text = kh.CustomerPhone;
            this.txtAge.Text = kh.CustomerAge.ToString();
            this.txtName.Text = kh.CustomerName;
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cus_edit_Click(object sender, EventArgs e)
        {
            try
            {
                customerDAO a = new customerDAO();

                int id = Convert.ToInt32(lbID.Text);
                string name = txtName.Text;
                int age = Convert.ToInt32(txtAge.Text);
                string phone = txtPhone.Text;
                string address = "";
                address = txtAddress.Text;

                RadioButton selected = null;
                string gender = "";
                foreach (RadioButton item in panel1.Controls)
                {
                    if (item != null)
                    {
                        if (item.Checked)
                        {
                            selected = item;
                            break;
                        }
                    }
                }
                if (selected != null)
                {
                    gender = selected.Text;
                }

                string level = txtLevel.Text;
                a.update_cus(id, name, age, phone, address, gender, level);
                MessageBox.Show("Lưu thay đổi thành công.");
                this.Close();
            } catch
            {
                MessageBox.Show("Vui lòng thử lại.");
            }
            
        }
    }
}
