using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;
using System.Threading.Tasks;
using PhotoGalleryLab1.Models;
using System.Threading;
using System;

namespace PhotoGalleryLab1.Controllers
{
    public class HomeController : AsyncController       // Update Index for Asynchronous operations.
    {
        //public ActionResult Index()
        //{
        //    var client = new HttpClient();
        //    var response = client.GetAsync(Url.Action("gallery", "photolab1", null, Request.Url.Scheme)).Result;
        //    var value = response.Content.ReadAsStringAsync().Result;

        //    var result = JsonConvert.DeserializeObject<List<PhotoLab1>>(value);

        //    return View(result);
        //}

        [AsyncTimeout(500)]
        [HandleError(ExceptionType = typeof(TimeoutException), View = "TimesOut")]
        public async Task<ActionResult> Index(CancellationToken cancellationToken)
        {
            var client = new HttpClient();
            var response = await client.GetAsync(Url.Action("gallery", "photolab1", null, Request.Url.Scheme), cancellationToken);
            var value = await response.Content.ReadAsStringAsync();

            var result = await JsonConvert.DeserializeObjectAsync<List<PhotoLab1>>(value);

            return View(result);
        }

        public ActionResult About()                 
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
