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
        
        public IActionResult AccessDenied()
        {
            return View();
        }
        public IActionResult Index()
        {
            ProductJoinSellerViewModel vm = new ProductJoinSellerViewModel();
            
            if (_contxt.HttpContext.Session.GetString("UserRole") == "Seller")
                vm.Products = db.Products.Where(p => p.SellerId == _contxt.HttpContext.Session.GetInt32("id")
                && p.IsDeleted==false).ToList();
            else 
                vm.Products = db.Products.Where(p=>p.IsDeleted==false).ToList();

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
                vm.Products = db.Products
                    .Where(p => p.SellerId == _contxt.HttpContext.Session.GetInt32("id") && p.Name.Contains(value) && p.IsDeleted == false)
                    .ToList();
            else
                vm.Products = db.Products.Where(p => p.Name.Contains(value) && p.IsDeleted == false).ToList();

            return View(vm);
        }

        public IActionResult Details(int id)
        {
            ProductWithQuantityViewModel vm = new ProductWithQuantityViewModel();
            Product p = db.Products.FirstOrDefault(s => s.Id == id);
            vm.product = p;
            vm.quantity = 1;

            if (p.IsDeleted == true) return RedirectToAction("AccessDenied");
            return View(vm);
        }

        public IActionResult New()
        {
            if (!string.IsNullOrEmpty(_contxt.HttpContext.Session.GetString("username"))
                && (_contxt.HttpContext.Session.GetString("UserRole") == UserRoles.Seller)){

                List<Seller> sellers = db.Sellers.ToList();
                ViewData["sellers"] = sellers;
                return View();
            }
            else
                return RedirectToAction("AccessDenied");


        }

        [HttpPost]
        public IActionResult SaveAfterNew(Product p)
        {
            if (!string.IsNullOrEmpty(_contxt.HttpContext.Session.GetString("username"))
               && (_contxt.HttpContext.Session.GetString("UserRole") == UserRoles.Seller))
            {

                p.IsDeleted = false;
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
            else
                return RedirectToAction("AccessDenied");
           


        }

       
       
        public IActionResult Edit(int id)
        {
            //sellers only can edit 
            if (!string.IsNullOrEmpty(_contxt.HttpContext.Session.GetString("username"))
               && (_contxt.HttpContext.Session.GetString("UserRole") == UserRoles.Seller))
            {
                Product prod = db.Products.Find(id);

                //only the seller of the product can edit it 
                if (prod.SellerId != _contxt.HttpContext.Session.GetInt32("id"))
                    return RedirectToAction("AccessDenied");

                List<Seller> sellers = db.Sellers.ToList();
                ViewData["sellers"] = sellers;

                return View(prod);

            }
            else
                return RedirectToAction("AccessDenied");

           
        }

        [HttpPost]
        public IActionResult SaveAfterEdit(Product NewP, int Id)
        {
            if (!string.IsNullOrEmpty(_contxt.HttpContext.Session.GetString("username"))
               && (_contxt.HttpContext.Session.GetString("UserRole") == UserRoles.Seller))
            {

                if (Id != _contxt.HttpContext.Session.GetInt32("id"))
                    return RedirectToAction("AccessDenied");
                Product OldP = db.Products.Find(Id);

                List<Seller> sellers = db.Sellers.ToList();
                ViewData["sellers"] = sellers;

                if (ModelState.IsValid == true)
                {
                    OldP.Name = NewP.Name;
                    OldP.Price = NewP.Price;
                    OldP.Description = NewP.Description;
                    OldP.Price = NewP.Price;
                    OldP.Quantity = NewP.Quantity;
                    OldP.Category = NewP.Category;
                    OldP.M_F = NewP.M_F;
                    OldP.Image = NewP.Image;
                    db.SaveChanges();
                    return RedirectToAction("index");

                }
                return View("Edit", NewP);


            }
            else
                return RedirectToAction("AccessDenied");


            
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (!string.IsNullOrEmpty(_contxt.HttpContext.Session.GetString("username"))
               && (_contxt.HttpContext.Session.GetString("UserRole") == UserRoles.Seller))
            {
                return View(db.Products.Find(id));

            }
            else
                return RedirectToAction("AccessDenied");
           
        }


        public IActionResult Delete2(int id)
        {
            if (!string.IsNullOrEmpty(_contxt.HttpContext.Session.GetString("username"))
              && (_contxt.HttpContext.Session.GetString("UserRole") == UserRoles.Seller))
            {
                Product pp = db.Products.Find(id);
                pp.IsDeleted = true;
                //db.Remove(pp);
                db.SaveChanges();
                return RedirectToAction("index");

            }
            else
                return RedirectToAction("AccessDenied");

           
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
            var test = db.OrderedProducts.Where(x => x.productID == op.productID && x.CardID == op.CardID && x.BuyerID == op.BuyerID).FirstOrDefault();

            if (test == null)
            {
                db.OrderedProducts.Add(op);
                db.SaveChanges();
            }
            else
            {
                test.Quantity += vm.quantity;
                
                db.SaveChanges();
            }
            

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
