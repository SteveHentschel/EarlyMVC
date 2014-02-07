using MyMusicStore.Filters;
using MyMusicStore.Models;
using MyMusicStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMusicStore.Controllers
{

    [CustomActionFilter]
    public class MyStoreController : Controller
    {
        private MusicStoreEntities storeDB = new MusicStoreEntities();

        // GET: /MyStore/
        //
        public ActionResult Index()
        {
            var genres = this.storeDB.Genres;

            return this.View(genres);
        }


        // GET: /Store/Browse?genre=Disco 
        //
        public ActionResult Browse(string genre)
        {
            // Retrieve Genre and its Associated Albums from database

            var genreModel = this.storeDB.Genres.Include("Albums").Single(g => g.Name == genre);

            return this.View(genreModel);
        }

        // GET: /Store/GenreMenu    (ok, called in _layout.cshtml)
        //
        [ChildActionOnly]
        public ActionResult GenreMenu()
        {
            var genres = this.storeDB.Genres.Take(9).ToList();

            return this.PartialView(genres);
        }


        // GET: /Store/Details/5    
        //
        public ActionResult Details(int id)
        {
            var album = this.storeDB.Albums.Find(id);

            if (album == null)
            {
                return this.HttpNotFound();
            }

            return this.View(album);
        }



    }
}
