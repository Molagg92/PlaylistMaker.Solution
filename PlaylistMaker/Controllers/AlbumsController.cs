using Microsoft.AspNetCore.Mvc;
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

    }
}