using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace db.bill
{
    public class Hobby
    {
        public static List<SelectListItem> GetHobby()
        {
            List<SelectListItem>list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Text ="吃饭",Value="eat ",Selected=true});
            list.Add(new SelectListItem() { Text = "睡觉", Value = "sleep " });
            return list;
        }
    }
}
