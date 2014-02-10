using MyMusicStore.Models;
using System.Collections.Generic;

namespace MyMusicStore.Services
{
    public interface IStoreService
    {
        IList<string> GetGenreNames();

        IList<Genre> GetGenres(int max = 0);

        Genre GetGenreByName(string name);

        Album GetAlbum(int id);
    }
}
