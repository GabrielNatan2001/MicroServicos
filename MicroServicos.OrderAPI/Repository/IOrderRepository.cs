using MicroServicos.OrderAPI.Model;

namespace MicroServicos.OrderAPI.Repository
{
    public interface IOrderRepository
    {
        Task<bool> AddOrder(OrderHeader header);
        Task UpdateOrderStatus(long orderHeaderId, bool paid);
    }
}
