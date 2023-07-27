using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebTicket.Business;
using WebTicket.DAL;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebTicket.Controllers
{
    public class LoginController : Controller
    {
        public WebContext db;
        public LoginController()
        {
            db = new WebContext();
        }

        
        public IActionResult Index()
        {
            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> Index(string kadi, string sifre)
        {
            var kontrol= db.Kullanici.FirstOrDefault(x=>x.Kadi==kadi && x.Sifre == sifre);
            if (kontrol !=null)
            {
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                identity.AddClaim(new Claim(ClaimTypes.Name, kadi));
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identity));

                return RedirectToAction("Index", "Admin");
            }
            else
            {
                ViewBag.Hata = "Kullanıcı adı veya şifre hatalı.";
                return View();
            }
        }
    }
}
