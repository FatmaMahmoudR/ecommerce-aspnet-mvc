using E_commerce.Models;
using E_commerce.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace E_commerce.Controllers
{
    public class ProductController : Controller
    {

        EcommerceCountext db = new EcommerceCountext();
        
        public IActionResult Index()
        {
            ProductJoinSellerViewModel vm = new ProductJoinSellerViewModel();
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
            var searchResults = db.Products.Where(p => p.Name.Contains(value));
            vm.Products = searchResults.ToList();

            return View(vm);
        }

        public IActionResult Details(int id)
        {

            Product p = db.Products.FirstOrDefault(s => s.Id == id);

            return View(p);
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
    }
}
