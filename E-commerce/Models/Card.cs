using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce.Models
{
    public class Card
    {

        [Key]
        public int Id { get; set; }

        [ForeignKey("Buyer")]
        public int? BuyerId { get; set; }

        public DateTime? DeliveryDate { get; set; }
        public string? ShippingStatus { get; set; }
        public bool? active { get; set; }   //current using card 

        public virtual Buyer? Buyer { get; set; }

        public virtual ICollection<OrderedProduct> OrderedProducts { get; set; } = new HashSet<OrderedProduct>();

    }
}