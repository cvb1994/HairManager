using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairManager.DAO
{
    class empDAO
    {
        HairManagerEntities db = new HairManagerEntities();

        public void addEmp(string name,int basesalary,int kpi)
        {
            nhanvien obj = new nhanvien();
            obj.employeeName = name;
            obj.base_salary = basesalary;
            obj.kpi = kpi;

            db.nhanviens.Add(obj);
            db.SaveChanges();
        }

        public void updateEmp(int id, string name, int basesalary, int kpi)
        {
            nhanvien obj = db.nhanviens.Find(id);
            obj.employeeName = name;
            obj.base_salary = basesalary;
            obj.kpi = kpi;

            db.SaveChanges();
        }

        public void deleteEmp(int id)
        {
            nhanvien obj = db.nhanviens.Find(id);
            db.nhanviens.Remove(obj);
            db.SaveChanges();
        }

        public nhanvien getDetail(int id)
        {
            nhanvien obj = db.nhanviens.Find(id);

            return obj;
        }

        public DataTable getEmp()
        {
            var list = from emp in db.nhanviens
                       select emp;
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Tên nhân viên");
            dt.Columns.Add("Lương cơ bản");

            DataRow row = null;
            
            foreach (nhanvien emp in list)
            {
                row = dt.NewRow();
                string s = string.Format("{0:#,##0}", emp.base_salary);
                dt.Rows.Add(emp.employeeID, emp.employeeName,s );
            }
            return dt;
        }

        public DataTable getStatic(int id, int timesearch)
        {
            DataTable dt = new DataTable();
            DateTime today = DateTime.Today;

            var firstDayOfCurrentMonth = new DateTime(today.Year, today.Month, 1);
            var lastDayOfCurrentMonth = firstDayOfCurrentMonth.AddMonths(1).AddDays(-1);

            var firstDayofPreMonth = firstDayOfCurrentMonth.AddMonths(-1);
            var lastDayofPreMonth = firstDayofPreMonth.AddMonths(1).AddDays(-1);

            var firstDayof2MonthBefore = firstDayofPreMonth.AddMonths(-1);
            var lastDayof2MonthBefore = firstDayof2MonthBefore.AddMonths(1).AddDays(-1);

            dt.Columns.Add("STT");
            dt.Columns.Add("Tên khách hàng");
            dt.Columns.Add("Dịch vụ");
            dt.Columns.Add("Ngày");
            dt.Columns.Add("KPI (VND)"); 
            dt.Columns.Add("KPI");
            int i = 1;
            DataRow row = null;

            var list = from ser in db.dichvus
                       where ser.employeeID == id
                       select ser;

            if (timesearch == 0)
            {
                foreach(dichvu ser in list)
                {
                    if((ser.dateCreated >= firstDayOfCurrentMonth) &&
                        (ser.dateCreated <= lastDayOfCurrentMonth)){
                        row = dt.NewRow();
                        int kpi = (ser.ServicePrice * ser.nhanvien.kpi) / 100;
                        string s = string.Format("{0:#,##0}", kpi);
                        dt.Rows.Add(i,ser.khachhang.CustomerName,ser.ServiceNane,ser.dateCreated.ToString("dd-MM-yyyy"),s,kpi);
                    }
                }
            } else if (timesearch == 1)
            {
                foreach(dichvu ser in list)
                {
                    if((ser.dateCreated >= firstDayofPreMonth) &&
                        (ser.dateCreated <= lastDayofPreMonth)){
                        row = dt.NewRow();
                        int kpi = (ser.ServicePrice * ser.nhanvien.kpi) / 100;
                        string s = string.Format("{0:#,##0}", kpi);
                        dt.Rows.Add(i,ser.khachhang.CustomerName,ser.ServiceNane,ser.dateCreated.ToString("dd-MM-yyyy"), s,kpi);
                    }
                }
            } else if(timesearch == 2)
            {
                foreach (dichvu ser in list)
                {
                    if ((ser.dateCreated >= firstDayof2MonthBefore) &&
                        (ser.dateCreated <= lastDayof2MonthBefore))
                    {
                        row = dt.NewRow();
                        int kpi = (ser.ServicePrice * ser.nhanvien.kpi) / 100;
                        string s = string.Format("{0:#,##0}", kpi);
                        dt.Rows.Add(i, ser.khachhang.CustomerName, ser.ServiceNane, ser.dateCreated.ToString("dd-MM-yyyy"), s,kpi);
                    }
                }
            }

            return dt;
        }
    }
}
