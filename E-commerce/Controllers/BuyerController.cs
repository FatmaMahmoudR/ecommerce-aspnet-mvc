using E_commerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Controllers
{
    public class BuyerController : Controller
    {
        EcommerceCountext db = new EcommerceCountext();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {

            return View();
        }
        public IActionResult Register2(Buyer s)
        {
            if (db.Buyers.Any(x => x.username == s.username))
            {
                ViewBag.Notification = "This username has already exit";
                return View("Register", s);
            }
            else if (db.Buyers.Any(y => y.Email == s.Email))
            {
                ViewBag.Notification = "This email address is already in use";
                return View("Register", s);
            }
            else
            {
                db.Buyers.Add(s);
                db.SaveChanges();

                HttpContext.Session.SetString("username", s.username.ToString());
                HttpContext.Session.SetString("id", s.Id.ToString());

                return RedirectToAction("index", "Buyer");
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
                HttpContext.Session.SetString("username", buyer.username);
                HttpContext.Session.SetString("id", buyer.Id.ToString());
                return RedirectToAction("Index", "User");
            }
            else
            {
                ViewBag.Notification = "Invalid username or password";
                return View();
            }
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
}
}
