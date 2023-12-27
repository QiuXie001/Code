using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary.bill
{
    public class Custom
    {
        public static void regist(DBLibrary.Custom entry)
        {
            mvcStudyEntities db = new mvcStudyEntities();
            db.Custom.Add(entry);
            db.Configuration.ValidateOnSaveEnabled = false;
            db.SaveChanges();
        }
    }
}
