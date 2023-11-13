using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db.bill
{
    public class Order
    {
        public static void insert(int bookid, int num, string address)
        {
            mvcStudyEntities db = new mvcStudyEntities();
            db.Orders entry = new db.Orders();
            entry.BookId = bookid;
            entry.Num = num;
            entry.Address = address;
            db.Orders.Add(entry);
            db.SaveChanges();
        }
    }
}
