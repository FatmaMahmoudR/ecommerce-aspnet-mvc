using E_commerce.Models;

namespace E_commerce.ViewModels
{
    public class CardJoinProduct
    {
        public Card card { get; set; }
        public List<Product> products { get; set; }
    }
}
