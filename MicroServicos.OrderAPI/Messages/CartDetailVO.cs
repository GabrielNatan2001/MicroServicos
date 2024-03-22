namespace MicroServicos.OrderAPI.Model
{
    public class CartDetailVO
    {
        public long CartHeaderId { get; set; }
        public long ProductId { get; set; }
        public virtual ProductVO Product { get; set; }
        public int Count { get; set; }
    }
}
