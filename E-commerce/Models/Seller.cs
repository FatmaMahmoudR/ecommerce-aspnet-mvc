using System.ComponentModel.DataAnnotations;

namespace E_commerce.Models
{
    public class Seller : User
    {
        public string? Bio { get; set; }
        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();

    }
}
