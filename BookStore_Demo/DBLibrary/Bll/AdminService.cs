using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary.Bll
{
    public class AdminService
    {
        public static List<DBLibrary.Admin> GetAllAdmin()
        {
            StoreContext db = new StoreContext();
            var admins = db.Admins.ToList();
            return admins;
        }
        public static DBLibrary.Admin GetAdmin(int id)
        {
            StoreContext db = new StoreContext();
            var entry = db.Admins.FirstOrDefault(b => b.Id == id);
            DBLibrary.Admin admin = new DBLibrary.Admin();
            admin = entry;
            return admin;
        }
        public static void regist(DBLibrary.Admin entry)
        {
            StoreContext db = new StoreContext();
            db.Admins.Add(entry);
            db.Configuration.ValidateOnSaveEnabled = false;
            db.SaveChanges();
        }
        public static void Update(DBLibrary.Admin entry)
        {
            StoreContext db = new StoreContext();
            db.Admins.Attach(entry);
            db.Entry(entry).State = EntityState.Modified;

            db.Configuration.ValidateOnSaveEnabled = false;

            db.SaveChanges();
            
        }
        public static List<Admin> Search(int id, string telephone)
        {
            StoreContext db = new StoreContext();
            var entry = db.Admins.Where(b => b.Id == id || b.Telephone == telephone);
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
            StoreContext db = new StoreContext();
            var admin = db.Admins.FirstOrDefault(b => b.Id == id);
            db.Admins.Remove(admin);
            db.SaveChanges();

        }
    }

}
