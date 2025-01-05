using Microsoft.AspNetCore.Mvc;

namespace SoldierMgtSys.Controllers;

public class PortalController : Controller
{
    // GET
    public IActionResult Index()
    {
        return RedirectToAction("Index", "Soldier");
    }
}