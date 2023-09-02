using E_commerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Controllers
{
    public class CardController : Controller
    {
        EcommerceCountext db = new EcommerceCountext();
        public IActionResult Index(int id)
        {

            Card c = db.Cards.FirstOrDefault(x => x.BuyerId == id);

            return View(c);
        }
    }
}
