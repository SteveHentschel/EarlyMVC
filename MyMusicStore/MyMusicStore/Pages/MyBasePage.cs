using Microsoft.Practices.Unity;
using MyMusicStore.Models;
using MyMusicStore.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMusicStore.Pages
{
    public class MyBasePage : System.Web.Mvc.WebViewPage<Genre>
    {
        [Dependency]
        public IMessageService MessageService { get; set; }

        public override void Execute()
        {
        }
    }
}