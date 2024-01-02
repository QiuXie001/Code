using System.Collections.Generic;
using System.Linq;

namespace DBLibrary.bill
{
    public class Order
    {
        public static List<DBLibrary.Orders> GetAllOrder(int CustomID)
        {
            mvcStudyEntities db = new mvcStudyEntities();
            var entry = db.Orders.Where(b => b.CustomID == CustomID);
            List<DBLibrary.Orders> list = new List<DBLibrary.Orders>();
            int j = 0;
            foreach (var i in entry)
            {
                if (entry != null)
                while (j == 0 || i.OrderID != list[j - 1].OrderID) 
                {
                list.Add(i);
                j++;
                }   
            }
            return list;
        }
        public static List<DBLibrary.Orders> Search(int id, string address)
        {
            mvcStudyEntities db = new mvcStudyEntities();
            var entry = db.Orders.Where(b => b.OrderID == id || b.Address == address);
            List<DBLibrary.Orders> list = new List<DBLibrary.Orders>();
            int j = 0;
            foreach (var i in entry)
            {
                list.Add(i);
                j++;
            }
            return list;
        }
    }
}
