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

    [HttpGet]
    public JsonResult GetPlaylists()
    {
        List<Playlist> playlists = _db.Playlists.ToList();
        return Json(playlists);
    }

    [HttpPost]
    public JsonResult AddSongToPlaylist(int songId, int playlistId)
    {
        PlaylistSongEntity playlistSong = new PlaylistSongEntity
        {
            SongId = songId,
            PlaylistId = playlistId
        };

        _db.PlaylistSongEntities.Add(playlistSong);
        _db.SaveChanges();

        return Json(new { success = true });
    }

    public ActionResult Index()
    {
        List<Playlist> model = _db.Playlists.ToList();
        return View(model);
    }

    public ActionResult Details(int id)
    {
        Playlist currentPlaylist = _db.Playlists.Include(p => p.PlaylistSongEntities)
                                                .ThenInclude(pse => pse.Song)
                                                .FirstOrDefault(p => p.PlaylistId == id);
        return View(currentPlaylist);
    }

    public ActionResult Create()
    {
        ViewData["FormRoute"] = "Create";
        ViewData["ButtonValue"] = "Add New Playlist";
        return View("Form");
    }

    [HttpPost]
    public IActionResult Create(Playlist playlist)
    {
        if (playlist.Name != null)
        {
            _db.Playlists.Add(playlist);
            _db.SaveChanges();
            return RedirectToAction("Details", "Playlists", new { id = playlist.PlaylistId });
        }

        ViewData["FormRoute"] = "Create";
        ViewData["ButtonValue"] = "Add New Playlist";
        return View("Form");
    }

    public ActionResult Edit(int id)
    {
        // Get the playlist from the db that matches the id.
        Playlist currentPlaylist = _db.Playlists.FirstOrDefault(p => p.PlaylistId == id);

        ViewData["FormRoute"] = "Edit";
        ViewData["ButtonValue"] = "Save Changes";
        return View("Form", currentPlaylist);
    }

    [HttpPost]
    public ActionResult Edit(int id, Playlist playlist)
    {
        Playlist existingPlaylist = _db.Playlists.FirstOrDefault(p => p.PlaylistId == id);

        if (existingPlaylist == null)
        {
            return NotFound();
        }

        existingPlaylist.Name = playlist.Name
        _db.SaveChanges();

        return RedirectToAction("Index");
    }


}