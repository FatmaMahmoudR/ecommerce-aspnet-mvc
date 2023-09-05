using E_commerce.Models;
using E_commerce.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Controllers
{
    public class CardController : Controller
    {
        EcommerceCountext db = new EcommerceCountext();
        public IActionResult Index(int id)
        {
            CardJoinProduct vm = new CardJoinProduct();
            
            Card c = db.Cards.FirstOrDefault(x => x.BuyerId == id);

            vm.card = c;
            vm.card.OrderedProducts = db.OrderedProducts.Where(x=>x.BuyerID == id).ToList();
            vm.products= db.Products.ToList();
            return View(vm);
        }
    }
}
