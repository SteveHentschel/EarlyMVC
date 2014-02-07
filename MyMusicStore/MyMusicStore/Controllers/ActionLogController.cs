using MyMusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMusicStore.Controllers
{
    public class ActionLogController : Controller
    {
        private MusicStoreEntities storeDB = new MusicStoreEntities();

        // GET: /ActionLog/
        public ActionResult Index()
        {
            var model = this.storeDB.ActionLogs.OrderByDescending(al => al.DateTime).ToList();

            return this.View(model);
        }
    }
}
