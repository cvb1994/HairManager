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
    public partial class add_customer : Form
    {
        customerDAO a = new customerDAO();
        public add_customer()
        {
            InitializeComponent();
        }

        private void cus_insert_Click(object sender, EventArgs e)
        {
            try
            {
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

                if (a.checkCus(phone))
                {
                    a.add_cus(name, age, phone, address, gender, level);
                    MessageBox.Show("Thêm mới thành công.");
                    txtName.Clear();
                    txtPhone.Clear();
                    txtAge.Clear();
                    txtAddress.Clear();
                    
                } else
                {
                    MessageBox.Show("Khách hàng đã tồn tại.");
                }
                
            }
            catch
            {
                MessageBox.Show("Vui lòng thử lại.");
            }
            
            
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
