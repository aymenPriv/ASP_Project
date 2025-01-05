using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SoldierMgtSys.Models;

namespace SoldierMgtSys.Controllers;

public class AccountController : Controller
{
    private readonly SignInManager<AppUser> signInManager;
    private readonly UserManager<AppUser> userManager;

    public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
    {
        this.signInManager = signInManager;
        this.userManager = userManager;
    }
    
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var result = await signInManager.PasswordSignInAsync(model.Username!, model.Password!, model.RememberMe, false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Portal");
            }
            
            ModelState.AddModelError("", "Invalid login attempt");
            return View(model);
        }
        
        return View(model);
    }
    
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            AppUser user = new()
            {
                Name = model.Name,
                UserName = model.Email,
                Email = model.Email,
                Address = model.Address,
            };
            
            var result = await userManager.CreateAsync(user, model.Password!);
            
            if (result.Succeeded)
            {
               await signInManager.SignInAsync(user, false);
               
               return RedirectToAction("Index", "Portal");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }
        return View(model);
    }
    
    public async Task<IActionResult> Logout()
    {
        await signInManager.SignOutAsync();
               
        return RedirectToAction(nameof(HomeController.Index), "Home");
    }
}