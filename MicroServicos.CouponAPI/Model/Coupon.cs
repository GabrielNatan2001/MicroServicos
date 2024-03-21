using MicroServicos.CouponAPI.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroServicos.CouponAPI.Model
{
    [Table("Coupon")]
    public class Coupon: BaseEntity
    {
        [Required]
        [MaxLength(30)]
        public string CouponCode{ get; set; }

        [Required]
        public decimal DiscountAmount{ get; set; }
    }
}
