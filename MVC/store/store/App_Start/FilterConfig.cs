﻿using store.Uitl.Filters;
using System.Web;
using System.Web.Mvc;

namespace store
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new Filters.LoginFilteringAttribute());
            filters.Add(new TimingActionFilter());
            filters.Add(new Filters.ErrorAttribute());  
        }
    }
}