using System;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary.Bll
{
    public class CustomService
    {
        public static List<DBLibrary.Custom> GetAllCustom()
        {
            StoreContext db = new StoreContext();
            var custom = db.Customs.ToList();
            return custom;
        }
        public static DBLibrary.Custom GetCustom(int id)
        {
            StoreContext db = new StoreContext();
            var entry = db.Customs.FirstOrDefault(b => b.Id == id);
            DBLibrary.Custom custom = new DBLibrary.Custom();
            custom = entry;
            return custom;
        }
        public static void regist(DBLibrary.Custom entry)
        {
            StoreContext db = new StoreContext();
            db.Customs.Add(entry);
            db.Configuration.ValidateOnSaveEnabled = false;
            db.SaveChanges();
        }
        public static void Update(DBLibrary.Custom entry)
        {
            StoreContext db = new StoreContext();
            db.Customs.Attach(entry);
            db.Configuration.ValidateOnSaveEnabled = false;
            db.SaveChanges();
        }
        public static List<DBLibrary.Custom> Search(int id , string telephone)
        {
            StoreContext db = new StoreContext();
            var entry = db.Customs.Where(b => b.Id == id||b.Telephone == telephone);
            List < DBLibrary.Custom > list = new List< DBLibrary.Custom >();
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
            var custom = db.Customs.FirstOrDefault(b => b.Id == id);
            db.Customs.Remove(custom);
            db.SaveChanges();
            
        }
    }
}
