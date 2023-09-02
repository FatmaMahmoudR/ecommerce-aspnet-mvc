using E_commerce.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Category? Category { get; set; }
        [DisplayName("For")]
        public Gender? M_F { get; set; }
        public int? Quantity { get; set; }
        public double? Price { get; set; }

        public string? Image { get; set; }

        [ForeignKey("Seller")]
        public int SellerId { get; set; }

        public virtual Seller? Seller { get; set;}
        public virtual ICollection<OrderedProduct> OrderedProducts { get; set; } = new HashSet<OrderedProduct>();

    }
}
