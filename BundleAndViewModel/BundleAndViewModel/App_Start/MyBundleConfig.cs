using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace BundleAndViewModel.App_Start
{
    public class MyBundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/Bundles").Include(
               "~/MyScripts/*.js"));

            BundleTable.EnableOptimizations = true;
        }
    }
}