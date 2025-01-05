using Microsoft.AspNetCore.Mvc;

namespace SoldierMgtSys.Controllers;

public class LandingController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}