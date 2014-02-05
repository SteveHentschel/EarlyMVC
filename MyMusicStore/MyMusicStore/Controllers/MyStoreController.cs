﻿using MyMusicStore.Models;
using MyMusicStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMusicStore.Controllers
{
    public class MyStoreController : Controller
    {
        //
        // GET: /MyStore/

        public ActionResult Index()
        {
            // Create a list of genres
            var genres = new List<string> { "Rock", "Jazz", "Country", "Pop", "Disco", "Queen" };

            // Create our view model
            var viewModel = new MyStoreIndexVM
            {
                NumberOfGenres = genres.Count(),
                Genres = genres
            };

            ViewBag.Starred = new List<string> { "Rock", "Jazz", "Queen" };

            return this.View(viewModel);
        }


        // GET: /Store/Browse?genre=Disco 
  
        public ActionResult Browse(string genre)
        {
            var genreModel = new Genre()
            {
                Name = genre
            };

            var albums = new List<Album>()
            {
                new Album() { Title = genre + " Album 1" },
                new Album() { Title = genre + " Album 2" }
            };

            var viewModel = new MyStoreBrowseVM()
            {
                Genre = genreModel,
                Albums = albums
            };

            return this.View(viewModel);
        }


        // GET: /Store/Details/5    

        public ActionResult Details(int id)
        {
            var album = new Album { Title = "Sample Album" };

            return this.View(album);
        }



    }
}
