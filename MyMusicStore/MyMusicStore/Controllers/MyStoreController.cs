using MyMusicStore.Filters;
using MyMusicStore.Services;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc3;

namespace MyMusicStore.Controllers
{

    [MyNewCAF(Order = 1)]
    [CustomActionFilter(Order = 2)]
    public class MyStoreController : Controller
    {
        private IStoreService service;

        public MyStoreController(IStoreService service)
        {
            this.service = service;
        }

        // GET: /Store/
        public ActionResult Details(int id)
        {
            var album = this.service.GetAlbum(id);
            if (album == null)
            {
                return this.HttpNotFound();
            }

            return this.View(album);
        }

        public ActionResult Browse(string genre)
        {
            // Retrieve Genre and its Associated Albums from database
            var genreModel = this.service.GetGenreByName(genre);

            return this.View(genreModel);
        }

        public ActionResult Index()
        {
            var genres = this.service.GetGenres();

            return this.View(genres);
        }

        // GET: /Store/GenreMenu
        public ActionResult GenreMenu()
        {
            var genres = this.service.GetGenres(9);

            return this.PartialView(genres);
        }

    }
}
