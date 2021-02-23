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
    public partial class billExport : Form
    {
        serviceDAO a = new serviceDAO();
        public billExport(int id)
        {
            InitializeComponent();
            dichvu obj = a.getDetail(id);
            lbCusName.Text = obj.khachhang.CustomerName;
            lbCusPhone.Text = obj.khachhang.CustomerPhone;
            lbSerName.Text = obj.ServiceNane;
            lbEmpName.Text = obj.nhanvien.employeeName;
            lbSerPrice.Text = string.Format("{0:#,##0}", obj.ServicePrice) + " VND";
            switch (obj.khachhang.CustomerLevel)
            {
                case "Đồng":
                    lbDiscount.Text = "0 %";
                    break;
                case "Bạc":
                    lbDiscount.Text = "5 %";
                    break;
                case "Vàng":
                    lbDiscount.Text = "10 %";
                    break;
                case "Kim Cương":
                    lbDiscount.Text = "20 %";
                    break;
            }
            lbTotalPrice.Text = string.Format("{0:#,##0}", obj.PriceDiscount) + " VND";
        }

        private void btConfirm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
