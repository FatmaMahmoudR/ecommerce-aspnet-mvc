using E_commerce.Data.Static;
using E_commerce.Models;
using Microsoft.AspNetCore.Mvc;
using System.Web.Providers.Entities;

namespace E_commerce.Controllers
{
    public class BuyerController : Controller
    {
        EcommerceCountext db = new EcommerceCountext();

        private readonly IHttpContextAccessor _contxt;

        public BuyerController(IHttpContextAccessor c)
        {
            _contxt = c;
        }

        public IActionResult Index()
        {
            var U = db.Buyers.ToList();
            return View(U);
           
        }
        public IActionResult Profile()
        {
            return View();
        }

        public IActionResult Register()
        {

            return View();
        }
        public IActionResult Register2(Buyer s)
        {
            if (db.Buyers.Any(x => x.username == s.username) && db.Sellers.Any(x => x.username == s.username))
            {
                ViewBag.Notification = "This username has already exist";
                return View("Register", s);
            }
            else if (db.Buyers.Any(y => y.Email == s.Email) && db.Sellers.Any(y => y.Email == s.Email))
            {
                ViewBag.Notification = "This email address is already in use";
                return View("Register", s);
            }
            else
            {
                db.Buyers.Add(s);
                db.SaveChanges();

                //HttpContext.Session.SetString("username", s.username);
                //HttpContext.Session.SetString("id", s.Id.ToString());
                //HttpContext.Session.SetString("UserRole", UserRoles.Buyer);

                return RedirectToAction("Login");
            }

        }

        public IActionResult Login()
        {
            return View();
        }

      
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var buyer = db.Buyers.FirstOrDefault(x => x.username == username && x.password == password);

            if (buyer != null)
            {
                _contxt.HttpContext.Session.SetString("username", buyer.username);
                _contxt.HttpContext.Session.SetInt32("id", buyer.Id);
                _contxt.HttpContext.Session.SetString("UserRole", UserRoles.Buyer);

               
                TempData["SessionId"] = HttpContext.Session.GetString("id");
                TempData["SessionUsername"] = HttpContext.Session.GetString("username");
                TempData["SessionUserRole"] = HttpContext.Session.GetString("UserRole");


                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Notification = "Invalid username or password";
                return View();
            }
        }

        
    }
}


