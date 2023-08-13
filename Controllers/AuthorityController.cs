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
    private AuthorityModel _authModel = new();

    private Authority auth = new();

    public IActionResult AuthPage()
    {
        return View(_authModel);
    }

    [HttpPost]
    public IActionResult AuthPage(string? login, string? pswd)
    {
        _authModel.Login = login;
        _authModel.Password = pswd;

        if (auth.LoginDataIsCorrect(login, pswd))
        {
            _authModel.isCorrect = true;

            return View("../Home/Index");
        } else _authModel.isCorrect = false;

        return View(_authModel);
    }
}