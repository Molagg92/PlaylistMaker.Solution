using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using PlaylistMaker.Models;
using System.Collections.Generic;

namespace PlaylistMaker.Controllers
{
    public class SongsController : Controller
    {
        private readonly PlaylistMakerContext _db;
        public SongsController(PlaylistMakerContext db)
        {
            _db = db;
        }

        public ActionResult Details(int id)
        {
            Song currentSong = _db.Songs.Include(s => s.Album)
                                        .Include(s => s.PlaylistSongEntities)
                                        .ThenInclude(pse => pse.Playlist)
                                        .FirstOrDefault(s => s.SongId == id);
            return View(currentSong);
        }

        public ActionResult Create()
        {
            ViewBag.AlbumId = new SelectList(_db.Albums, "AlbumId", "Title");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Song song)
        {
            //ModelState.IsValid
            if (ModelState.IsValid)
            {
                _db.Songs.Add(song);
                _db.SaveChanges();
                return RedirectToAction("Details", "Songs", new { id = song.SongId });
            }
            ViewBag.AlbumId = new SelectList(_db.Albums, "AlbumId", "Title");
            return View();
        }

    }
}