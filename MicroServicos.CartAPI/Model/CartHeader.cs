using MicroServicos.CartAPI.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroServicos.CartAPI.Model
{
    [Table("CartHeader")]
    public class CartHeader: BaseEntity
    {
        public string UserId { get; set; }
        public string CouponCode { get; set; }
    }
}
