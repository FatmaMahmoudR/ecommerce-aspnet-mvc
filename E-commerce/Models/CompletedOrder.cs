using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce.Models
{

   
    public class CompletedOrder
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Buyer")]
        public int? BuyerId { get; set; }

        public virtual Buyer? Buyer { get; set; }
        public virtual ICollection<Card> cards { get; set; } = new HashSet<Card>();  
    }
}
