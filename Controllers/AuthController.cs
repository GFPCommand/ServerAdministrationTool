﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ServerAdministrationTool.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {    
        public IActionResult AuthPage()
        {
            return View();
        }
    }
}