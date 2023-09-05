using E_commerce.Data.Static;
using E_commerce.Models;
using E_commerce.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Runtime.Intrinsics.X86;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace E_commerce.Controllers
{
    public class ProductController : Controller
    {

        EcommerceCountext db = new EcommerceCountext();

        private readonly IHttpContextAccessor _contxt;

        public ProductController(IHttpContextAccessor c)
        {
            _contxt = c;
        }
        public IActionResult Index()
        {
            ProductJoinSellerViewModel vm = new ProductJoinSellerViewModel();
            
            if (_contxt.HttpContext.Session.GetString("UserRole") == "Seller")
                vm.Products = db.Products.Where(p => p.SellerId == _contxt.HttpContext.Session.GetInt32("id")).ToList();
            else 
                vm.Products = db.Products.ToList();

            vm.Sellers = db.Sellers.ToList(); 

            return View(vm);
        }

        [HttpGet]
        public IActionResult Search(String value)
        {
            if (value == null) { return RedirectToAction("Index"); }
            ProductJoinSellerViewModel vm = new ProductJoinSellerViewModel();
          
            vm.Sellers = db.Sellers.ToList();

            if (_contxt.HttpContext.Session.GetString("UserRole") == "Seller")
                vm.Products = db.Products.Where(p => p.SellerId == _contxt.HttpContext.Session.GetInt32("id") && p.Name.Contains(value)).ToList();
            else
                vm.Products = db.Products.Where(p => p.Name.Contains(value)).ToList();

            return View(vm);
        }

        public IActionResult Details(int id)
        {
            ProductWithQuantityViewModel vm = new ProductWithQuantityViewModel();
            Product p = db.Products.FirstOrDefault(s => s.Id == id);
            vm.product = p;
            vm.quantity = 1;
           


            return View(vm);
        }

        public IActionResult New()
        {
            List<Seller> sellers = db.Sellers.ToList();
            ViewData["sellers"] = sellers;
            return View();
        }

        [HttpPost]
        public IActionResult SaveAfterNew(Product p)
        {
            List<Seller> sellers = db.Sellers.ToList();
            ViewData["sellers"] = sellers;

           

            if (ModelState.IsValid == true)
            {
                p.SellerId = (int)_contxt.HttpContext.Session.GetInt32("id");
                db.Products.Add(p);

                db.SaveChanges();
                return RedirectToAction("index", p);
            }
            else
                return View("New", p);


        }

       
       
        public IActionResult Edit(int id)
        {

            Product prod = db.Products.Find(id);

            List<Seller> sellers = db.Sellers.ToList();
            ViewData["sellers"] = sellers;

            return View(prod);
        }
        [HttpPost]
        public IActionResult SaveAfterEdit(Product NewP, int Id)
        {
           Product OldP = db.Products.Find(Id);

            List<Seller> sellers = db.Sellers.ToList();
            ViewData["sellers"] = sellers;

            if (ModelState.IsValid == true)
            {
                OldP.Name= NewP.Name;
                OldP.Price= NewP.Price;
                OldP.Description= NewP.Description;
                OldP.Price= NewP.Price;
                OldP.Quantity= NewP.Quantity;
                OldP.Category= NewP.Category;
                OldP.M_F= NewP.M_F;
                OldP.Image= NewP.Image;
                db.SaveChanges();
                return RedirectToAction("index");

            }
            return View("Edit", NewP);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(db.Products.Find(id));
        }


        public IActionResult Delete2(int id)
        {
           Product pp = db.Products.Find(id);
            db.Remove(pp);
            db.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpPost]
        public  ActionResult AddItemToCard(ProductWithQuantityViewModel vm)
        {
            //assign item as ordered 
            OrderedProduct op = new OrderedProduct();
            op.productID = vm.product.Id;
            op.BuyerID = (int)_contxt.HttpContext.Session.GetInt32("id");
            op.Quantity = vm.quantity;

            //retreive the active card of the customer from database to update it with the new added product
            Card c = db.Cards.Where(x => x.BuyerId == op.BuyerID && x.active==true).FirstOrDefault();
            op.CardID = c.Id;
            db.OrderedProducts.Add(op);
            db.SaveChanges();

            //increase card session by 1

            c.OrderedProducts = db.OrderedProducts.Where(x => x.BuyerID == op.BuyerID && x.Card.active==true).ToList();
            _contxt.HttpContext.Session.SetInt32("card", c.OrderedProducts.Count());

           

            // minus the ordered quantity of this item from the available amount
            Product OldP = db.Products.Find(op.productID);
            
            OldP.Quantity -= vm.quantity;

            db.SaveChanges();

             return RedirectToAction("index");
        }


        //Action to Redirect to pevious page 
        public IActionResult RedirectToPreviousView()
        {
            string previousUrl = Request.Headers["Referer"].ToString();

            if (!string.IsNullOrEmpty(previousUrl))
            {
                return Redirect(previousUrl);
            }
            else
            {
                // Handle the case when there is no previous view
                return RedirectToAction("Index", "Home"); // Redirect to a default page
            }
        }

        public IActionResult unavailableProduct ()
        {
            return View();
        }



    }
}
