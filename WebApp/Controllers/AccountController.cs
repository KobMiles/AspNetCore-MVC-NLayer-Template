using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using BLL.DTOs.Users;
using BLL.Interfaces.Services;
using WebApp.Attributes;

namespace WebApp.Controllers;

public class AccountController(IAuthService authService, IUserService userService) : Controller
{

    [HttpGet, AllowAnonymousOnly]
    public IActionResult Register() => View();

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(UserRegisterDto model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var result = await authService.RegisterAsync(model);
        if (result.Succeeded)
        {
            TempData["Success"] = "Registration successful! You can now log in.";

            return RedirectToAction(nameof(Login));
        }

        foreach (var error in result.Errors)
            ModelState.AddModelError(string.Empty, error.Description);

        return View(model);
    }

    [HttpGet, AllowAnonymousOnly]
    public IActionResult Login(string? returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl;

        return View();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(UserLoginDto model, string? returnUrl = null)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var result = await authService.LoginAsync(model);

        if (result.Succeeded)
        {
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        if (result.IsLockedOut)
            ModelState.AddModelError(string.Empty, "Account locked. Try again later.");

        else
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");

        return View(model);
    }

    [HttpPost, Authorize, ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await authService.LogoutAsync();

        return RedirectToAction(nameof(Login));
    }

    [HttpGet, Authorize]
    public async Task<IActionResult> Profile()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var userDetails = await userService.GetUserDetailsAsync(userId!);
        if (userDetails == null)
            return NotFound();

        return View(userDetails);
    }
}