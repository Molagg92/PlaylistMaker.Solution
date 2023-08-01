using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using PlaylistMaker.Models;
using System.Collections.Generic;

namespace PlaylistMaker.Controllers;

public class PlaylistsController : Controller
{
    private readonly PlaylistMakerContext _db;
    public PlaylistsController(PlaylistMakerContext db)
    {
        _db = db;
    }

    public ActionResult Index()
    {
        List<Playlist> model = _db.Playlists.ToList();
        return View(model);
    }

    public ActionResult Details(int id)
    {
        Playlist currentPlaylist = _db.Playlists
                                          .Include(p => p.PlaylistSongEntities)
                                          .ThenInclude(pse => pse.Song)
                                          .FirstOrDefault(p => p.PlaylistId == id);
        return View(currentPlaylist);
    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(Playlist playlist)
    {
        _db.Playlists.Add(playlist);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
}