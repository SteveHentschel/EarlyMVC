﻿using MyMusicStore.Filters;
using System.Web;
using System.Web.Mvc;

namespace MyMusicStore
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
   //         filters.Add(new MyNewCAF());                  // added for Filter lab, removed for DI lab
        }
    }
}