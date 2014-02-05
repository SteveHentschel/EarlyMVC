using MyMusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMusicStore.ViewModels
{
    public class MyStoreBrowseVM
    {
        public List<Album> Albums { get; set; }

        public Genre Genre { get; set; }
    }
}