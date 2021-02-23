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
    public partial class Login : Form
    {
        userDAO obj = new userDAO();

        public Login()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            int id=0;
            id = obj.login_check(txtUsername.Text, txtPassword.Text);
            if(id != 0)
            {
                MainMenu a = new MainMenu(id);
                a.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.");
            }
        }

        private void btSetting_Click(object sender, EventArgs e)
        {
            settingConnect a = new settingConnect();
            this.Hide();
            a.ShowDialog();
            this.Show();
        }
    }
}
