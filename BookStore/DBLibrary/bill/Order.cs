using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DBLibrary.bill
{
    public class Order
    {
        public static List<DBLibrary.Orders> GetOrder(int CustomID)
        {
            mvcStudyEntities db = new mvcStudyEntities();
            var entry = db.Orders.Where(b => b.CustomID == CustomID).Select(x => x.OrderID).Distinct();
            List<DBLibrary.Orders> list = new List<DBLibrary.Orders>();
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
        public static List<DBLibrary.Orders> GetAllOrder(int AdminID)
        {
            mvcStudyEntities db = new mvcStudyEntities();
            var entry = db.Orders.ToList().Select(x => x.OrderID).Distinct();
            List<DBLibrary.Orders> list = new List<DBLibrary.Orders>();
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
        public static List<DBLibrary.Orders> Search(int? id, string telephone,int CustomID)
        {
            mvcStudyEntities db = new mvcStudyEntities();
            if (id != 0 && telephone != "")
            {
                var entry = db.Orders.Where(b => b.CustomID == CustomID).Select(x => x.OrderID).Distinct();
                List<DBLibrary.Orders> list = new List<DBLibrary.Orders>();
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
                List<DBLibrary.Orders> list = new List<DBLibrary.Orders>();
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
                List<DBLibrary.Orders> list = new List<DBLibrary.Orders>();
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
                List<DBLibrary.Orders> list = new List<DBLibrary.Orders>();
                
                return list;
            }
        }
        public static List<DBLibrary.Orders> Search(int? id, string telephone)
        {
            mvcStudyEntities db = new mvcStudyEntities();
            if (id != 0 && telephone != "")
            {
                var entry = db.Orders.ToList().Select(x => x.OrderID).Distinct();
                List<DBLibrary.Orders> list = new List<DBLibrary.Orders>();
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
                List<DBLibrary.Orders> list = new List<DBLibrary.Orders>();
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
                List<DBLibrary.Orders> list = new List<DBLibrary.Orders>();
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
                List<DBLibrary.Orders> list = new List<DBLibrary.Orders>();

                return list;
            }
        }
        public static void InsertOrder(List<DBLibrary.Orders> Orders)
        {
            mvcStudyEntities db = new mvcStudyEntities();
            foreach (var i in Orders)
            {
                db.Orders.Add(i);
            }
            db.SaveChanges();
        }
        public static void Clear(long id)
        {
            mvcStudyEntities db = new mvcStudyEntities();
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
            mvcStudyEntities db = new mvcStudyEntities();
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
            mvcStudyEntities db = new mvcStudyEntities();
            var entry = db.Orders.Where(b => b.OrderID == id);
            foreach (var i in entry)
            {
                db.Orders.Remove(i);
            }
            db.SaveChanges();
        }
    }
}
