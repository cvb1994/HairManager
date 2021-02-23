using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairManager.DAO
{
    class serviceDAO
    {
        HairManagerEntities db = new HairManagerEntities();

        public dichvu addService(string name,int price,string des,int cus_id,int emp_id)
        {
            dichvu obj = new dichvu();
            khachhang kh = db.khachhangs.Find(cus_id);

            obj.ServiceNane = name;
            obj.ServicePrice = price;
            obj.ServiceDescribe = des;

            switch (kh.CustomerLevel)
            {
                case "Đồng":
                    obj.PriceDiscount = price;
                    break;
                case "Bạc":
                    obj.PriceDiscount = (int)Math.Ceiling(price - price * 0.05);
                    break;
                case "Vàng":
                    obj.PriceDiscount = (int)Math.Ceiling(price - price * 0.1);
                    break;
                case "Kim Cương":
                    obj.PriceDiscount = (int)Math.Ceiling(price - price * 0.2);
                    break;
            }
            DateTime today = DateTime.Today;
            obj.dateCreated = today;
            obj.CustomerID = cus_id;
            obj.employeeID = emp_id;

            db.dichvus.Add(obj);
            kh.CustomerCosted += obj.PriceDiscount;

            db.SaveChanges();

            return obj;
        }

        public DataTable getData()
        {
            DataTable dt = new DataTable();
            var list = from ser in db.dichvus
                       orderby ser.dateCreated descending
                       select ser;
            dt.Columns.Add("STT");
            dt.Columns.Add("Tên khách hàng");
            dt.Columns.Add("Dịch Vụ");
            dt.Columns.Add("Chi phí (VND)");
            dt.Columns.Add("Chiết khấu (%)");
            dt.Columns.Add("Thanh toán (VND)");
            dt.Columns.Add("Ngày");
            dt.Columns.Add("Nhân Viên");
            dt.Columns.Add("ID");
            DataRow row = null;
            int i = 1;
            int discount = 0;
            foreach (dichvu ser in list)
            {
                switch (ser.khachhang.CustomerLevel)
                {
                    case "Đồng":
                        discount = 0;
                        break;
                    case "Bạc":
                        discount = 5;
                        break;
                    case "Vàng":
                        discount = 10;
                        break;
                    case "Kim Cương":
                        discount = 20;
                        break;
                }

                row = dt.NewRow();
                string s1 = string.Format("{0:#,##0}", ser.ServicePrice);
                string s2 = string.Format("{0:#,##0}", ser.PriceDiscount);

                dt.Rows.Add(i, ser.khachhang.CustomerName, ser.ServiceNane, s1 ,discount,s2, ser.dateCreated.ToString("dd-MM-yyyy"), ser.nhanvien.employeeName,
                    ser.ServiceID);
                i++;
            }

            return dt;
        }

        public dichvu getDetail(int id)
        {
            dichvu obj = new dichvu();
            obj = db.dichvus.Find(id);
            return obj;
        }

        public void updateService(int id, string name, int price, string des, int emp_id)
        {
            dichvu obj = db.dichvus.Find(id);
            obj.ServiceNane = name;
            obj.ServicePrice = price;
            obj.ServiceDescribe = des;
            obj.employeeID = emp_id;

            db.SaveChanges();
        }

        public DataTable getCustomerData(int id)
        {
            DataTable dt = new DataTable();
            var list = from ser in db.dichvus
                       where ser.CustomerID == id
                       orderby ser.dateCreated descending
                       select ser;
            dt.Columns.Add("STT");
            dt.Columns.Add("Dịch Vụ");
            dt.Columns.Add("Chi phí (VND)");
            dt.Columns.Add("Chiết khấu (%)");
            dt.Columns.Add("Thanh toán (VND)");
            dt.Columns.Add("Ngày");
            dt.Columns.Add("Nhân Viên");
            dt.Columns.Add("ID");
            DataRow row = null;
            int i = 1;
            int discount = 0;
            foreach (dichvu ser in list)
            {
                switch (ser.khachhang.CustomerLevel)
                {
                    case "Đồng":
                        discount = 0;
                        break;
                    case "Bạc":
                        discount = 5;
                        break;
                    case "Vàng":
                        discount = 10;
                        break;
                    case "Kim Cương":
                        discount = 20;
                        break;
                }

                row = dt.NewRow();
                string s1 = string.Format("{0:#,##0}", ser.ServicePrice);
                string s2 = string.Format("{0:#,##0}", ser.PriceDiscount);

                dt.Rows.Add(i, ser.ServiceNane, s1, discount, s2, ser.dateCreated.ToString("dd-MM-yyyy"), ser.nhanvien.employeeName,
                    ser.ServiceID);
                i++;
            }

            return dt;
        }

        public DataTable getByDay(DateTime date)
        {
            DataTable dt = new DataTable();
            var list = from ser in db.dichvus
                       where ser.dateCreated == date
                       select ser;
            dt.Columns.Add("STT");
            dt.Columns.Add("Tên khách hàng");
            dt.Columns.Add("Dịch Vụ");
            dt.Columns.Add("Chi phí (VND)");
            dt.Columns.Add("Chiết khấu (%)");
            dt.Columns.Add("Thanh toán (VND)");
            dt.Columns.Add("Nhân Viên");
            dt.Columns.Add("ID");
            dt.Columns.Add("Thanh toán");
            DataRow row = null;
            int i = 1;
            int discount = 0;
            foreach (dichvu ser in list)
            {
                switch (ser.khachhang.CustomerLevel)
                {
                    case "Đồng":
                        discount = 0;
                        break;
                    case "Bạc":
                        discount = 5;
                        break;
                    case "Vàng":
                        discount = 10;
                        break;
                    case "Kim Cương":
                        discount = 20;
                        break;
                }
                row = dt.NewRow();
                string s1 = string.Format("{0:#,##0}", ser.ServicePrice);
                string s2 = string.Format("{0:#,##0}", ser.PriceDiscount);

                dt.Rows.Add(i, ser.khachhang.CustomerName, ser.ServiceNane, s1, discount,s2, ser.nhanvien.employeeName,
                    ser.ServiceID, ser.PriceDiscount);
                i++;
            }
            return dt;
        }
    }
}
