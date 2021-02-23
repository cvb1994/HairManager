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
    public partial class addUser : Form
    {
        userDAO a = new userDAO();
        public addUser()
        {
            InitializeComponent();
        }

        private void btAddUser_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtUsername.Text;
                string pass = txtPass.Text;
                string confirm = txtPassConfirm.Text;
                string role = txtRole.Text;
                if (pass == confirm && a.checkUser(name))
                {
                    a.addUser(name, pass, role);
                    MessageBox.Show("Thêm mới thành công.");
                } else
                {
                    MessageBox.Show("Tài khoản này đã tồn tại.");

                }
                
            } catch
            {
                MessageBox.Show("Vui lòng thử lại.");
            }
            
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
