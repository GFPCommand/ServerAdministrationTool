using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServerAdministrationTool.Models;
using System.Security.Claims;

namespace ServerAdministrationTool.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private static bool isSuccess = true;

        public IActionResult Index()
        {
            return View(new ErrorViewModel { IsSuccess = isSuccess });
        }

        [HttpPost]
        public async Task<IActionResult> Authorization(string login, string pswd)
        {
            Authority auth = new();

            if (!auth.LoginDataIsCorrect(login!, pswd!))
            {
                isSuccess = false;
                return RedirectToAction("Index");
            }

            isSuccess = true;

            var claims = new List<Claim> { new(ClaimTypes.Name, login!) };
            var claimsIdentity = new ClaimsIdentity(claims, "Cookie");
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            await HttpContext.SignInAsync(claimsPrincipal);
            return Redirect("/Home");
        }
    }
}
