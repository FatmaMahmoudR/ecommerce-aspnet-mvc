using E_commerce.Models;
using E_commerce.ViewModels;
using Microsoft.AspNetCore.Mvc;

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
    }
}
