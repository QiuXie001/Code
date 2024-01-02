using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary.bill
{
    public class Admin
    {
        public static List<DBLibrary.Admin> GetAllAdmin()
        {
            mvcStudyEntities db = new mvcStudyEntities();
            var admins = db.Admin.ToList();
            return admins;
        }
        public static DBLibrary.Admin GetAdmin(int id)
        {
            mvcStudyEntities db = new mvcStudyEntities();
            var entry = db.Admin.FirstOrDefault(b => b.Admin_ID == id);
            DBLibrary.Admin admin = new DBLibrary.Admin();
            admin = entry;
            return admin;
        }
        public static void regist(DBLibrary.Admin entry)
        {
            mvcStudyEntities db = new mvcStudyEntities();
            db.Admin.Add(entry);
            db.Configuration.ValidateOnSaveEnabled = false;
            db.SaveChanges();
        }
        public static void Update(DBLibrary.Admin entry)
        {
            mvcStudyEntities db = new mvcStudyEntities();
            var custom = db.Admin.FirstOrDefault(b => b.Admin_ID == entry.Admin_ID);
            if (custom != null)
            {
                custom = entry;
                db.SaveChanges();
            }
        }
        public static List<DBLibrary.Admin> Search(int id, string telephone)
        {
            mvcStudyEntities db = new mvcStudyEntities();
            var entry = db.Admin.Where(b => b.Admin_ID == id || b.Admin_Telephone == telephone);
            List<DBLibrary.Admin> list = new List<DBLibrary.Admin>();
            int j = 0;
            foreach (var i in entry)
            {
                list.Add(i);
                j++;
            }
            return list;
        }
        public static void Delete(int id)
        {
            mvcStudyEntities db = new mvcStudyEntities();
            var admin = db.Admin.FirstOrDefault(b => b.Admin_ID == id);
            db.Admin.Remove(admin);
            db.SaveChanges();

        }
    }

}
