using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using MyMusicStore.Models;

namespace MyMusicStore.Controllers
{
    public class MyStoreMgrController : Controller
    {
        private MusicStoreEntities db = new MusicStoreEntities();

        //
        // GET: /MyStoreMgr/

        public ActionResult Index()
        {
            var albums = this.db.Albums.Include(a => a.Genre)
                                    .Include(a => a.Artist)
                                    .OrderBy(p => p.Price);

            return this.View(albums.ToList());
        }

        //
        // GET: /MyStoreMgr/Details/5

        //public ActionResult Details(int id = 0)
        //{
        //    Album album = db.Albums.Find(id);
        //    if (album == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(album);
        //}

        //
        // GET: /MyStoreMgr/Create

        public ActionResult Create()
        {
            this.ViewBag.GenreId = new SelectList(this.db.Genres, "GenreId", "Name");
            this.ViewBag.ArtistId = new SelectList(this.db.Artists, "ArtistId", "Name");

            return this.View();
        }

        //
        // POST: /MyStoreMgr/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Album album)
        {
            if (ModelState.IsValid)
            {
                this.db.Albums.Add(album);
                this.db.SaveChanges();

                return this.RedirectToAction("Index");
            }

            this.ViewBag.GenreId = new SelectList(this.db.Genres, "GenreId", "Name", album.GenreId);
            this.ViewBag.ArtistId = new SelectList(this.db.Artists, "ArtistId", "Name", album.ArtistId);

            return this.View(album);
        }

        //
        // GET: /MyStoreMgr/Edit/5

        public ActionResult Edit(int id)
        {
            Album album = this.db.Albums.Find(id);

            if (album == null)
            {
                return this.HttpNotFound();
            }

            this.ViewBag.GenreId = new SelectList(this.db.Genres, "GenreId", "Name", album.GenreId);
            this.ViewBag.ArtistId = new SelectList(this.db.Artists, "ArtistId", "Name", album.ArtistId);

            return this.View(album);
        }

        //
        // POST: /MyStoreMgr/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Album album)
        {
            if (ModelState.IsValid)
            {
                this.db.Entry(album).State = EntityState.Modified;
                this.db.SaveChanges();

                return this.RedirectToAction("Index");
            }

            this.ViewBag.GenreId = new SelectList(this.db.Genres, "GenreId", "Name", album.GenreId);
            this.ViewBag.ArtistId = new SelectList(this.db.Artists, "ArtistId", "Name", album.ArtistId);

            return this.View(album);
        }

        //
        // GET: /MyStoreMgr/Delete/5

        public ActionResult Delete(int id)
        {
            Album album = this.db.Albums.Find(id);

            if (album == null)
            {
                return this.HttpNotFound();
            }

            return this.View(album);
        }

        //
        // POST: /MyStoreMgr/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            Album album = this.db.Albums.Find(id);
            this.db.Albums.Remove(album);
            this.db.SaveChanges();

            return this.RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}