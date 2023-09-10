using E_commerce.Data.Static;
using E_commerce.Models;
using E_commerce.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;


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

            if (!string.IsNullOrEmpty(_contxt.HttpContext.Session.GetString("username"))
              && (_contxt.HttpContext.Session.GetString("UserRole") == UserRoles.Buyer))

            {
                //TempData["SessionId"] = HttpContext.Session.GetString("id");
                Buyer buyer = db.Buyers.Find(HttpContext.Session.GetInt32("id"));
                return View(buyer);

            }
            else
                return RedirectToAction("AccessDenied", "Product");

            
        }

        [HttpPost]
        public IActionResult SaveChange(Buyer NewP, int Id)
        {
            Buyer OldP = db.Buyers.Find(Id);


            
                OldP.Name = NewP.Name;
                OldP.Id = NewP.Id;
                OldP.username = NewP.username;
               
                OldP.Phone = NewP.Phone;
                OldP.ProfilePicture = NewP.ProfilePicture;
                OldP.AccCreationDate = NewP.AccCreationDate;

                OldP.Email = NewP.Email;
                db.SaveChanges();
                return RedirectToAction("Index", "Home");

            
            return View("Profile", NewP);
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


                db.Buyers.Add(s);
                db.SaveChanges();

                //create initial card for the user
                Card BCard = new Card();
                BCard.BuyerId = s.Id;
                BCard.active = true;
                db.Cards.Add(BCard);
                db.SaveChanges();

                _contxt.HttpContext.Session.SetString("username", s.username);
                _contxt.HttpContext.Session.SetInt32("id", s.Id);
                _contxt.HttpContext.Session.SetString("UserRole", UserRoles.Buyer);

                //to show the number of items in the shopping card button
                Card c = db.Cards.FirstOrDefault(x => x.BuyerId == s.Id);
                c.OrderedProducts = db.OrderedProducts.Where(x => x.BuyerID == s.Id).ToList();

                _contxt.HttpContext.Session.SetInt32("card", c.OrderedProducts.Count());


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
            var buyer = db.Buyers.FirstOrDefault(x => x.username == username && x.password == password);

            if (buyer != null)
            {
                _contxt.HttpContext.Session.SetString("username", buyer.username);
                _contxt.HttpContext.Session.SetInt32("id", buyer.Id);
                _contxt.HttpContext.Session.SetString("UserRole", UserRoles.Buyer);

                //to show the number of items in the shopping card button
                Card c = db.Cards.FirstOrDefault(x => x.BuyerId == buyer.Id);
                if (c != null)
                {
                    c.OrderedProducts = db.OrderedProducts.Where(x => x.BuyerID == buyer.Id).ToList();

                    _contxt.HttpContext.Session.SetInt32("card", c.OrderedProducts.Count());
                }
              


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

        public IActionResult PrevOrders(int id)
        {
            if (!string.IsNullOrEmpty(_contxt.HttpContext.Session.GetString("username"))
                && (_contxt.HttpContext.Session.GetString("UserRole") == UserRoles.Buyer)
                && ( id == _contxt.HttpContext.Session.GetInt32("id") ))
                
            {

                PrevOrderViewModel vm = new PrevOrderViewModel();
                var result = db.OrderedProducts
               .Where(op => op.BuyerID == id)
               .GroupBy(op => op.CardID)
               .Where(g => g.Count() >= 1)
              .Select(g => new
              {
                  CardID = g.Key,
                  OrderedProducts = g.ToList()
              })
              .ToList();

                List<List<OrderedProduct>> listOfCards = result.Select(item => item.OrderedProducts).ToList();
                vm.products = db.Products.ToList();
                vm.LLOP = listOfCards;
                return View(vm);


            }
            else
                return RedirectToAction("AccessDenied","Product");
           

        }
    }
    
}


