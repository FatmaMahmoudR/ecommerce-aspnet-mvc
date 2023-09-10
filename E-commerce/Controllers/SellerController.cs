using E_commerce.Models;
using Microsoft.AspNetCore.Mvc;
using E_commerce.Data.Static;
using NuGet.Protocol.Plugins;
using E_commerce.ViewModels;

namespace E_commerce.Controllers
{
    public class SellerController : Controller
    {
        EcommerceCountext db = new EcommerceCountext();

        private readonly IHttpContextAccessor _contxt;

        public SellerController(IHttpContextAccessor c)
        {
            _contxt = c;
        }
        public IActionResult Index()
        {
            var U = db.Sellers.ToList();
            return View(U);
        }

        public IActionResult Profile()
        {
            if (!string.IsNullOrEmpty(_contxt.HttpContext.Session.GetString("username"))
               && (_contxt.HttpContext.Session.GetString("UserRole") == UserRoles.Seller))

            {
                Seller seller = db.Sellers.Find(_contxt.HttpContext.Session.GetInt32("id"));

                return View(seller);


            }
            else
                return RedirectToAction("AccessDenied", "Product");
            
        }

        [HttpPost]
        public IActionResult SaveChange(Seller NewP, int Id)
        {
            Seller OldP = db.Sellers.Find(Id);

            
            
            
                OldP.Name = NewP.Name;
                OldP.Id = NewP.Id;
                
                OldP.Phone = NewP.Phone;
                OldP.ProfilePicture = NewP.ProfilePicture;
                OldP.AccCreationDate = NewP.AccCreationDate;
                OldP.Bio = NewP.Bio;
                OldP.Email = NewP.Email;
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            
            return View("Profile", NewP);
        }


        public IActionResult Register()
        {
            
            return View();
        }
        public IActionResult Register2(Seller s)
        {
            if (db.Buyers.Any(x => x.username == s.username) && db.Sellers.Any(x => x.username == s.username))
            {
                ViewBag.Notification = "This username has already exist";
                return View("Register");
            }
            else if (db.Buyers.Any(y => y.Email == s.Email) && db.Sellers.Any(y => y.Email == s.Email))
            {
                ViewBag.Notification = "This email address is already in use";
                return View("Register");
            }
            else
            {
                s.AccCreationDate = DateTime.Now;
                db.Sellers.Add(s);
                db.SaveChanges();

                _contxt.HttpContext.Session.SetString("username", s.username);
                _contxt.HttpContext.Session.SetInt32("id", s.Id);
                _contxt.HttpContext.Session.SetString("UserRole", UserRoles.Seller);


                TempData["SessionId"] = HttpContext.Session.GetString("id");
                TempData["SessionUsername"] = HttpContext.Session.GetString("username");
                TempData["SessionUserRole"] = HttpContext.Session.GetString("UserRole");


                return RedirectToAction("Index", "Home");
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
                _contxt.HttpContext.Session.SetString("username", seller.username);
                _contxt.HttpContext.Session.SetInt32("id", seller.Id);
                _contxt.HttpContext.Session.SetString("UserRole", UserRoles.Seller);


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


