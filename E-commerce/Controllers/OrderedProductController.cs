using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Controllers
{
    public class OrderedProductController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}
