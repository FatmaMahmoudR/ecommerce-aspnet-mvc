using System.ComponentModel.DataAnnotations;

namespace E_commerce.Models
{
    public class Seller : User
    {
        [MaxLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string? Bio { get; set; }
        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();

    }
}
