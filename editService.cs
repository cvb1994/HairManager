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
    public partial class editService : Form
    {
        serviceDAO a = new serviceDAO();
        empDAO b = new empDAO();
        int serviceID;
        imageDAO c = new imageDAO();
        List<anh> imgList;
        ListViewItem lstviewItem;
        ImageList lstviewItemImageList = new ImageList();

        //Lưu Id image cần xóa được lưu trong tag
        List<int> removeImageList = new List<int>() ;

        List<anh> addImageList = new List<anh>();

        public editService(int id)
        {
            InitializeComponent();
            serviceID = id;
            dichvu obj = a.getDetail(id);
            this.lbDisplayName.Text = obj.khachhang.CustomerName;
            this.lbDisplayPhone.Text = obj.khachhang.CustomerPhone;
            this.txtServiceName.Text = obj.ServiceNane;
            this.txtPrice.Text = string.Format("{0:#,##0}", obj.ServicePrice);
            this.txtDes.Text = obj.ServiceDescribe;
            for (int i = 0; i < b.getEmp().Rows.Count; i++)
            {
                string text = b.getEmp().Rows[i]["ID"].ToString() + "- " + b.getEmp().Rows[i]["Tên nhân viên"].ToString();
                this.txtEmp.Items.Add(text);
                if (b.getEmp().Rows[i]["Tên nhân viên"].ToString() == obj.nhanvien.employeeName)
                {
                    this.txtEmp.Text = b.getEmp().Rows[i]["ID"].ToString() + "- " + b.getEmp().Rows[i]["Tên nhân viên"].ToString();
                }
            }

            imgList = c.imageList(id);
            lstviewItemImageList.ColorDepth = ColorDepth.Depth32Bit;
            listView1.View = View.LargeIcon;
            listView1.Columns.Add("File");
            listView1.Columns[0].Width = 500;
            imgLoad();
        }

        public void imgLoad()
        {
            foreach (anh img in imgList)
            {
                lstviewItem = new ListViewItem(img.path);
                lstviewItem.Tag = img.imageID;
                lstviewItemImageList.ImageSize = new Size(150, 150);
                listView1.LargeImageList = lstviewItemImageList;
                listView1.SmallImageList = lstviewItemImageList;
                lstviewItem.ImageIndex = lstviewItemImageList.Images.Add(Image.FromFile(lstviewItem.Text), Color.Transparent);
                listView1.Items.Add(lstviewItem);
            }
        }

        private void btAddImage_Click(object sender, EventArgs e)
        {
            var obj = new OpenFileDialog();
            obj.InitialDirectory = "C://Desktop";
            obj.Title = "Chọn ảnh cần lưu";
            obj.Filter = "Image Only(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            obj.Multiselect = true;

            if (obj.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                obj.FileNames.ToList().ForEach(file =>
                {
                    string filename = System.IO.Path.GetFileName(file);
                    string directorypath = Path.GetDirectoryName(obj.FileName);
                    string path = directorypath + "\\" + filename;
                    anh obj1 = new anh();
                    obj1.path = path;
                    imgList.Add(obj1);
                    addImageList.Add(obj1);
                });

            }
            listView1.Clear();
            imgLoad();



        }

        private void btRemoveImage_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Bạn có chắc muốn xóa ảnh.",
                                     "Xác Nhận Xóa",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                foreach (ListViewItem item in listView1.SelectedItems)
                {
                    ListViewItem selecteditem = item;
                    int selectedId = Convert.ToInt32(selecteditem.Tag.ToString());
                    if (selectedId != 0)
                    {
                        removeImageList.Add(selectedId);
                        listView1.Items.Remove(selecteditem);
                    }
                    else
                    {
                        listView1.Items.Remove(selecteditem);
                    }
                }
                
            }

        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (int selectedid in removeImageList)
                {
                    c.removeImage(selectedid);
                }
                foreach (anh img in addImageList)
                {
                    c.addImage(img.path, serviceID);
                }

                string name = txtServiceName.Text;
                int price = convertText(txtPrice.Text);
                string des = txtDes.Text;

                int count = txtEmp.Text.IndexOf("-");
                int emp_id = Convert.ToInt32(txtEmp.Text.Substring(0, count));
                a.updateService(serviceID, name, price, des, emp_id);
                MessageBox.Show("Lưu thay đổi thành công.");
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
