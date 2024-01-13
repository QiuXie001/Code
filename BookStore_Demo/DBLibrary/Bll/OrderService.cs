using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DBLibrary.Bll
{
    public class OrderService
    {
        public static List<DBLibrary.Order> GetOrder(int CustomID)
        {
            StoreContext db = new StoreContext();
            var entry = db.Orders.Where(b => b.CustomID == CustomID).Select(x => x.OrderID).Distinct();
            List<DBLibrary.Order> list = new List<DBLibrary.Order>();
            foreach (var i in entry)
            {
                if (entry != null)
                {
                    var order = db.Orders.FirstOrDefault(o => o.OrderID == i);
                    if(order!=null)
                    list.Add(order);
                }
            }
            return list;
        }
        public static List<DBLibrary.Order> GetAllOrder(int AdminID)
        {
            StoreContext db = new StoreContext();
            var entry = db.Orders.ToList().Select(x => x.OrderID).Distinct();
            List<DBLibrary.Order> list = new List<DBLibrary.Order>();
            foreach (var i in entry)
            {
                if (entry != null)
                {
                    var order = db.Orders.FirstOrDefault(o => o.OrderID == i);
                    if (order != null)
                        list.Add(order);
                }
            }
            return list;
        }
        public static List<DBLibrary.Order> Search(int? id, string telephone,int CustomID)
        {
            StoreContext db = new StoreContext();
            if (id != 0 && telephone != "")
            {
                var entry = db.Orders.Where(b => b.CustomID == CustomID).Select(x => x.OrderID).Distinct();
                List<DBLibrary.Order> list = new List<DBLibrary.Order>();
                foreach (var i in entry)
                {
                    if (entry != null)
                    {
                        var order = db.Orders.FirstOrDefault(o => o.OrderID == i&&o.OrderID==id && o.Custom_Telephone == telephone);
                        if (order != null)
                            list.Add(order);
                    }
                }
                return list;
            }
            else if (id != 0 && telephone == "")
            {
                var entry = db.Orders.Where(b => b.CustomID == CustomID).Select(x => x.OrderID).Distinct();
                List<DBLibrary.Order> list = new List<DBLibrary.Order>();
                foreach (var i in entry)
                {
                    if (entry != null)
                    {
                        var order = db.Orders.FirstOrDefault(o => o.OrderID == i && o.OrderID == id);
                        if (order != null)
                            list.Add(order);
                    }
                }
                return list;
            }
            else if (id == 0 && telephone != "")
            {
                var entry = db.Orders.Where(b => b.CustomID == CustomID).Select(x => x.OrderID).Distinct();
                List<DBLibrary.Order> list = new List<DBLibrary.Order>();
                foreach (var i in entry)
                {
                    if (entry != null)
                    {
                        var order = db.Orders.FirstOrDefault(o => o.OrderID == i && o.Custom_Telephone == telephone);
                        if (order != null)
                            list.Add(order);
                    }
                }
                return list;
            }
            else
            {
                List<DBLibrary.Order> list = new List<DBLibrary.Order>();
                
                return list;
            }
        }
        public static List<DBLibrary.Order> Search(int? id, string telephone)
        {
            StoreContext db = new StoreContext();
            if (id != 0 && telephone != "")
            {
                var entry = db.Orders.ToList().Select(x => x.OrderID).Distinct();
                List<DBLibrary.Order> list = new List<DBLibrary.Order>();
                foreach (var i in entry)
                {
                    if (entry != null)
                    {
                        var order = db.Orders.FirstOrDefault(o => o.OrderID == i && o.OrderID == id && o.Custom_Telephone == telephone);
                        if (order != null)
                            list.Add(order);
                    }
                }
                return list;
            }
            else if (id != 0 && telephone == "")
            {
                var entry = db.Orders.ToList().Select(x => x.OrderID).Distinct();
                List<DBLibrary.Order> list = new List<DBLibrary.Order>();
                foreach (var i in entry)
                {
                    if (entry != null)
                    {
                        var order = db.Orders.FirstOrDefault(o => o.OrderID == i && o.OrderID == id);
                        if (order != null)
                            list.Add(order);
                    }
                }
                return list;
            }
            else if (id == 0 && telephone != "")
            {
                var entry = db.Orders.ToList().Select(x => x.OrderID).Distinct();
                List<DBLibrary.Order> list = new List<DBLibrary.Order>();
                foreach (var i in entry)
                {
                    if (entry != null)
                    {
                        var order = db.Orders.FirstOrDefault(o => o.OrderID == i && o.Custom_Telephone == telephone);
                        if (order != null)
                            list.Add(order);
                    }
                }
                return list;
            }
            else
            {
                List<DBLibrary.Order> list = new List<DBLibrary.Order>();

                return list;
            }
        }
        public static void InsertOrder(List<DBLibrary.Order> Orders)
        {
            StoreContext db = new StoreContext();
            foreach (var i in Orders)
            {
                db.Orders.Add(i);
            }
            db.SaveChanges();
        }
        public static void Clear(long id)
        {
            StoreContext db = new StoreContext();
            var entry = db.Orders.Where(b => b.OrderID == id);
            foreach (var i in entry)
            {
                i.ClearOrNot = true;
                db.Orders.Attach(i);
                db.Entry(i).State = EntityState.Modified;
            }
            db.SaveChanges();
        }
        public static void Receipt(long id)
        {
            StoreContext db = new StoreContext();
            var entry = db.Orders.Where(b => b.OrderID == id);
            foreach (var i in entry)
            {
                i.ReceiptOrNot = true;
                db.Orders.Attach(i);
                db.Entry(i).State = EntityState.Modified;
            }
            db.SaveChanges();
        }
        public static void Delete(long id)
        {
            StoreContext db = new StoreContext();
            var entry = db.Orders.Where(b => b.OrderID == id);
            foreach (var i in entry)
            {
                db.Orders.Remove(i);
            }
            db.SaveChanges();
        }
    }
}
