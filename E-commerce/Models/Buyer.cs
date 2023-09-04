using System.ComponentModel.DataAnnotations;

namespace E_commerce.Models
{
    public class Buyer : User
    {
        public virtual ICollection<ShippingInfo> ShippingInfos { get; set; } = new HashSet<ShippingInfo>();

        public virtual ICollection<OrderedProduct> OrderedProducts { get; set; } = new HashSet<OrderedProduct>();

    }
}