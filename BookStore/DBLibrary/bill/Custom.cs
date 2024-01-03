using System;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary.bill
{
    public class Custom
    {
        public static List<DBLibrary.Custom> GetAllCustom()
        {
            mvcStudyEntities db = new mvcStudyEntities();
            var custom = db.Custom.ToList();
            return custom;
        }
        public static DBLibrary.Custom GetCustom(int id)
        {
            mvcStudyEntities db = new mvcStudyEntities();
            var entry = db.Custom.FirstOrDefault(b => b.Custom_ID == id);
            DBLibrary.Custom custom = new DBLibrary.Custom();
            custom = entry;
            return custom;
        }
        public static void regist(DBLibrary.Custom entry)
        {
            mvcStudyEntities db = new mvcStudyEntities();
            db.Custom.Add(entry);
            db.Configuration.ValidateOnSaveEnabled = false;
            db.SaveChanges();
        }
        public static void Update(DBLibrary.Custom entry)
        {
            mvcStudyEntities db = new mvcStudyEntities();
            db.Custom.Attach(entry);
            db.Entry(entry).State = EntityState.Modified;
            db.SaveChanges();
        }
        public static List<DBLibrary.Custom> Search(int id , string telephone)
        {
            mvcStudyEntities db = new mvcStudyEntities();
            var entry = db.Custom.Where(b => b.Custom_ID == id||b.Custom_Telephone == telephone);
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
            mvcStudyEntities db = new mvcStudyEntities();
            var custom = db.Custom.FirstOrDefault(b => b.Custom_ID == id);
            db.Custom.Remove(custom);
            db.SaveChanges();
            
        }
    }
}
