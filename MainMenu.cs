using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HairManager.DAO;

namespace HairManager
{
    public partial class MainMenu : Form
    {
        userDAO obj = new userDAO();

        public string role;
        public MainMenu(int id)
        {
            InitializeComponent();
            nguoidung user = obj.getUserData(id);
            lbUserDisplay.Text = user.userName;
            role = user.userRole;
            
        }

        private void btAddCus_Click(object sender, EventArgs e)
        {
            add_customer a = new add_customer();
            this.Hide();
            a.ShowDialog();
            this.Show();
            
        }

        private void btListCus_Click(object sender, EventArgs e)
        {
            if(role == "admin")
            {
                listCustomer a = new listCustomer();
                this.Hide();
                a.ShowDialog();
                this.Show();
            } else
            {
                MessageBox.Show("Tài khoản này không có quyền truy cập.");
            }
        }

        private void btNewSer_Click(object sender, EventArgs e)
        {
            addService a = new addService();
            this.Hide();
            a.ShowDialog();
            this.Show();
        }

        private void btNewEmp_Click(object sender, EventArgs e)
        {
            if (role == "admin")
            {
                addEmployee a = new addEmployee();
                this.Hide();
                a.ShowDialog();
                this.Show();
            } else
            {
                MessageBox.Show("Tài khoản này không có quyền truy cập.");
            }
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (role == "admin")
            {
                listService a = new listService();
                this.Hide();
                a.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Tài khoản này không có quyền truy cập.");
            }
        }
           
        private void btNewUser_Click(object sender, EventArgs e)
        {
            if (role == "admin")
            {
                addUser a = new addUser();
                this.Hide();
                a.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Tài khoản này không có quyền truy cập.");
            }
            
        }

        private void btListEmp_Click(object sender, EventArgs e)
        {
            if (role == "admin")
            {
                listEmployee a = new listEmployee();
                this.Hide();
                a.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Tài khoản này không có quyền truy cập.");
            }
            
        }


        private void btStatistical_Click(object sender, EventArgs e)
        {
            if (role == "admin")
            {
                serStatic a = new serStatic();
                this.Hide();
                a.ShowDialog();
                this.Show();
            }

            else
            {
                MessageBox.Show("Tài khoản này không có quyền truy cập.");
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn thoát", "Some Title", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (dialogResult == DialogResult.No)
            {
                e.Cancel = true;
            }
            
        }
    }
}
