using E_commerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Web.Providers.Entities;

namespace E_commerce.Controllers
{
    public class SellerController : Controller
    {
        EcommerceCountext db = new EcommerceCountext();
       

        public IActionResult Index()
        {
            var U = db.Sellers.ToList();
            return View(U);
        }


        public IActionResult Register()
        {
            
            return View();
        } 
        public IActionResult Register2(Seller s)
        {
            if(db.Sellers.Any(x=>x.username == s.username))
            {
                ViewBag.Notification = "This username has already exit";
                return View("Register",s);
            }
            else if (db.Sellers.Any(y => y.Email == s.Email))
            {
                ViewBag.Notification = "This email address is already in use";
                return View("Register",s);
            }
            else
            {
                db.Sellers.Add(s);
                db.SaveChanges();

                HttpContext.Session.SetString("username", s.username.ToString());
                HttpContext.Session.SetString("id", s.Id.ToString());

                return RedirectToAction("index","User");
            }
            
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var seller = db.Sellers.FirstOrDefault(x => x.username == username && x.password == password);

            if (seller != null)
            {
                HttpContext.Session.SetString("username", seller.username);
                HttpContext.Session.SetString("id", seller.Id.ToString());
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


