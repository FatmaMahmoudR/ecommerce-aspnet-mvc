using E_commerce.Models;

namespace E_commerce.ViewModels
{
    public class AllUsersViewModel
    {
        public List<Seller>? seller { get; set; }
        public List<Buyer>? buyer { get; set; }
    }
}
