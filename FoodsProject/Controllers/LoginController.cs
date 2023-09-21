using FoodsProject.Data.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FoodsProject.Controllers
{
    public class LoginController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(Admin p)
        {
            var asd = c.Admins.FirstOrDefault(x => x.UserName == p.UserName && x.Password == p.Password);

            if (asd != null)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, p.UserName),
                };

                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);

                return RedirectToAction("Index", "Category");
            }

            return View();
        }
    }
}
