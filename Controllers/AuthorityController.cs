using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Server_Administration_Tool.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Connections.Features;
using System.Text;

namespace Server_Administration_Tool.Controllers;

[AllowAnonymous]
public class AuthorityController : Controller
{
    private User _user = new();

    private Authority auth = new();

    public IActionResult AuthPage()
    {
        return View(_user);
    }

    [HttpPost]
    public IActionResult AuthPage(string? login, string? pswd)
    {
        _user.Login = login;
        _user.Password = pswd;

        if (auth.LoginDataIsCorrect(login, pswd))
        {
            _user.isCorrect = true;

            return View("../Home/Index");
        } else _user.isCorrect = false;

        return View(_user);
    }
}