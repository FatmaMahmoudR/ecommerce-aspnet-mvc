using E_commerce.Models;

namespace E_commerce.ViewModels
{
    public class PrevOrderViewModel
    {
        public List<Product> products { get; set; }
        public List<List<OrderedProduct>> LLOP { get; set; }
    }
}
