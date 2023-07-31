using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using PlaylistMaker.Models;
using System.Collections.Generic;

namespace PlaylistMaker.Controllers
{
    public class ArtistsController : Controller
    {
        private readonly PlaylistMakerContext _db;
        public ArtistsController(PlaylistMakerContext db)
        {
            _db = db;
        }
        public ActionResult Index()
        {
            List<Artist> model = _db.Artists.ToList();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            Artist currentArtist = _db.Artists.Include(a => a.Albums)
                                              .FirstOrDefault(a => a.ArtistId == id);
            return View(currentArtist);

        }

    }
}