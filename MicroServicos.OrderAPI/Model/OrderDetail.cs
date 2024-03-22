using MicroServicos.OrderAPI.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroServicos.OrderAPI.Model
{
    [Table("OrderDetail")]
    public class OrderDetail: BaseEntity
    {
        public long OrderHeaderId { get; set; }
        [ForeignKey("OrderHeaderId")]
        public virtual OrderHeader OrderHeader { get; set; }
        public long ProductId { get; set; }
        public int Count { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
    }
}
