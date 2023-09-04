using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce.Models
{
    public class ShippingInfo
    {
        [Key]
        public int ShippinginfoID { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public int? PostalCode { get; set; }

        [ForeignKey("buyer")]
        public int? buyerID { get; set; }

        public virtual Buyer? buyer { get; set; }
    }
}