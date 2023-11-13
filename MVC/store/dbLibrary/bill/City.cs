using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace db.bill
{
    public class City
    {
        public static List<SelectListItem> GetCity()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Text = "南京", Value = "nanjing", Selected = true });
            list.Add(new SelectListItem() { Text = "上海", Value = "shanghai" });
            list.Add(new SelectListItem() { Text = "北京", Value = "beijing" });
            return list;
        }
    }
}
