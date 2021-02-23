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
    public partial class imageDisplay : Form
    {
        serviceDAO a = new serviceDAO();
        imageDAO c = new imageDAO();
        List<anh> imgList;
        ListViewItem lstviewItem;
        ImageList lstviewItemImageList = new ImageList();

        public imageDisplay(int id)
        {
            InitializeComponent();
            imgList = c.imageList(id);
            lstviewItemImageList.ColorDepth = ColorDepth.Depth32Bit;
            listView1.View = View.LargeIcon;
            listView1.Columns.Add("File");
            listView1.Columns[0].Width = 700;
            imgLoad();
            pictureBox1.Hide();
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void imgLoad()
        {
            foreach (anh img in imgList)
            {
                lstviewItem = new ListViewItem(img.path);
                lstviewItem.Tag = img.imageID;
                lstviewItemImageList.ImageSize = new Size(250, 250);
                listView1.LargeImageList = lstviewItemImageList;
                listView1.SmallImageList = lstviewItemImageList;
                lstviewItem.ImageIndex = lstviewItemImageList.Images.Add(Image.FromFile(lstviewItem.Text), Color.Transparent);
                listView1.Items.Add(lstviewItem);
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            string s="";
            foreach(ListViewItem item in listView1.SelectedItems)
            {
                ListViewItem selecteditem = item;
                s = selecteditem.Text;
            }
            Bitmap bm = new Bitmap(@"" + s);
            pictureBox1.Image = bm;
            pictureBox1.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Hide();
        }
    }
}
