﻿using MyMusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMusicStore.Services
{
    public class StoreService : IStoreService
    {
        private MusicStoreEntities storeDB = new MusicStoreEntities();

        public IList<string> GetGenreNames()
        {
            var genres = from genre in this.storeDB.Genres
                         select genre.Name;

            return genres.ToList();
        }

        public IList<Genre> GetGenres(int max)
        {
            return max > 0 ? this.storeDB.Genres.Take(max).ToList() : this.storeDB.Genres.ToList();
        }

        public Genre GetGenreByName(string name)
        {
            var genre = this.storeDB.Genres.Include("Albums").Single(g => g.Name == name);

            return genre;
        }

        public Album GetAlbum(int id)
        {
            var album = this.storeDB.Albums.Single(a => a.AlbumId == id);

            return album;
        }
    }
}