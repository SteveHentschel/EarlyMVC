using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMusicStore.ViewModels
{
    public class MyStoreIndexVM
    {
        public int NumberOfGenres { get; set; }

        public List<string> Genres { get; set; }
    }
}