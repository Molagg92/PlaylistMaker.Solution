using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PlaylistMaker.Models;

namespace PlaylistMaker.Controllers;

public class HomeController : Controller
{

    public IActionResult Index()
    {
        return View();
    }
}
