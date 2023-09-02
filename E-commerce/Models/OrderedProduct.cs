using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce.Models
{
    public class OrderedProduct
    {
        [Key]
        public int Id { get; set; }


        [ForeignKey("Product")]
        public int? productID { get; set; }
        [ForeignKey("Buyer")]
        public int? BuyerID { get; set; }

        [ForeignKey("Card")]
        public int? CardID { get; set; }
        public int? Quantity { get; set; }

        public virtual Product? Product { get; set; }
        public virtual Buyer? Buyer { get; set; }

        public virtual Card? Card { get; set; }


    }
}
