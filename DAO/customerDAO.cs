using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairManager.DAO
{
    class customerDAO
    {
        HairManagerEntities db = new HairManagerEntities();

        public DataTable getData()
        {
            var list = from cus in db.khachhangs
                       select cus;
            DataTable dt = new DataTable();
            dt.Columns.Add("STT");
            dt.Columns.Add("Tên khách hàng");
            dt.Columns.Add("Tuổi");
            dt.Columns.Add("Điện thoại");
            dt.Columns.Add("Địa chỉ");
            dt.Columns.Add("Giới tính");
            dt.Columns.Add("Cấp độ");
            dt.Columns.Add("Mức độ chi tiêu");
            dt.Columns.Add("ID");
            DataRow row = null;
            int i = 1;
            foreach (khachhang cus in list)
            {
                row = dt.NewRow();
                string s = string.Format("{0:#,##0}", cus.CustomerCosted);
                dt.Rows.Add(i,cus.CustomerName,cus.CustomerAge,cus.CustomerPhone,cus.CustomerAddress,cus.CustomerGender,cus.CustomerLevel,
                    s ,cus.CustomerID);
                i++;
            }

            return dt;
        }

        public khachhang getDetail(int id)
        {
            khachhang kh = db.khachhangs.Find(id);
            return kh;
        }

        public DataTable searchData(string search)
        {
            var listSearch = from cus in db.khachhangs
                             where cus.CustomerPhone == search || cus.CustomerName.Contains(search)
                             select cus;
            DataTable dt = new DataTable();
            dt.Columns.Add("STT");
            dt.Columns.Add("Tên khách hàng");
            dt.Columns.Add("Tuổi");
            dt.Columns.Add("Điện thoại");
            dt.Columns.Add("Địa chỉ");
            dt.Columns.Add("Giới tính");
            dt.Columns.Add("Cấp độ");
            dt.Columns.Add("Mức độ chi tiêu");
            dt.Columns.Add("ID");
            DataRow row = null;
            int i = 1;
            foreach (khachhang cus in listSearch)
            {
                row = dt.NewRow();
                string s = string.Format("{0:#,##0}", cus.CustomerCosted);
                dt.Rows.Add(i, cus.CustomerName, cus.CustomerAge, cus.CustomerPhone, cus.CustomerAddress, cus.CustomerGender, cus.CustomerLevel,
                    s, cus.CustomerID);
                i++;
            }
            return dt;
        }

        public void add_cus(string name, int age, string phone, string address, string gender, string level)
        {
            khachhang obj = new khachhang();
            obj.CustomerName = name;
            obj.CustomerAge = age;
            obj.CustomerPhone = phone;
            obj.CustomerAddress = address;
            obj.CustomerGender = gender;
            obj.CustomerLevel = level;
            DateTime today = DateTime.Today;
            obj.dateCreated = today;

            db.khachhangs.Add(obj);
            db.SaveChanges();

        }

        public void update_cus(int id,string name, int age, string phone, string address, string gender, string level)
        {
            khachhang obj = db.khachhangs.Find(id);
            obj.CustomerName = name;
            obj.CustomerAge = age;
            obj.CustomerPhone = phone;
            obj.CustomerAddress = address;
            obj.CustomerGender = gender;
            obj.CustomerLevel = level;

            db.SaveChanges();

        }

        public bool checkCus(string phone)
        {
            bool available = true;
            var list = from cus in db.khachhangs
                       select cus.CustomerPhone;

            foreach(string tel in list)
            {
                if(tel == phone)
                {
                    available = false;
                    break;
                }
            }
            return available;
        }
    }
}
