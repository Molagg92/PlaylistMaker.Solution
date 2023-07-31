using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PlaylistMaker.Models;

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

    }
}