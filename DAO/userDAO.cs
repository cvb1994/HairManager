using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairManager.DAO
{
    class userDAO
    {
        HairManagerEntities db = new HairManagerEntities();

        public nguoidung getUserData(int id)
        {
            nguoidung user = db.nguoidungs.Find(id);
            return user;
        }

        public int login_check(string username, string password)
        {
            int id = 0;
            var list = from user in db.nguoidungs
                       where user.userName == username && user.userPass == password
                       select user;
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("UserName");
            dt.Columns.Add("Pas");
            dt.Columns.Add("Role");
            DataRow row = null;
            foreach (nguoidung item in list)
            {
                row = dt.NewRow();
                dt.Rows.Add(item.userID, item.userName, item.userPass, item.userRole);
            }
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    id = Convert.ToInt32(dr["ID"].ToString());
                }
            }
            return id;
        }

        public void addUser(string name, string pass, string role)
        {
            nguoidung obj = new nguoidung();
            obj.userName = name;
            obj.userPass = pass;
            obj.userRole = role;

            db.nguoidungs.Add(obj);
            db.SaveChanges();
        }

        public bool checkUser(string name)
        {
            bool available = true;
            var list = from user in db.nguoidungs
                       select user.userName;

            foreach(string userName in list)
            {
                if(userName == name)
                {
                    available = false;
                    break;
                }
            }
            return available;
        }

        
    }
}
