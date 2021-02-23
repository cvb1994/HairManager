using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HairManager.DAO
{
    class imageDAO
    {
        HairManagerEntities db = new HairManagerEntities();

        public void addImage(string path,int serviceID)
        {
            anh obj = new anh();
            obj.path = path;
            obj.ServiceID = serviceID;

            db.anhs.Add(obj);
            db.SaveChanges();
        }

        public List<anh> imageList(int id)
        {
            List<anh> imageList = new List<anh>();

            var list = from img in db.anhs
                       where img.ServiceID == id
                       select img;
            imageList = list.ToList();

            return imageList;
        }

        public void removeImage(int id)
        {
            anh obj = db.anhs.Find(id);
            db.anhs.Remove(obj);
            db.SaveChanges();
        }

    }
}
