using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using PlaylistMaker.Models;
using System.Collections.Generic;


namespace PlaylistMaker.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly PlaylistMakerContext _db;
        public AlbumsController(PlaylistMakerContext db)
        {
            _db = db;
        }

        public ActionResult Details(int id)
        {
            Album currentAlbum = _db.Albums.Include(a => a.Songs)
                                              .FirstOrDefault(a => a.AlbumId == id);
            return View(currentAlbum);

        }
        public ActionResult Create()
        {
            ViewBag.ArtistId = new SelectList(_db.Artists, "ArtistId", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Album album)
        {
            if (album.Title != null)
            {
                _db.Albums.Add(album);
                _db.SaveChanges();
                return RedirectToAction("Details", "Albums", new { id = album.AlbumId });
            }
            return View();
        }
    }
}