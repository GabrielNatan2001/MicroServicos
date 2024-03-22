using MicroServicos.OrderAPI.Model.Context;
using MicroServicos.OrderAPI.Model;
using MicroServicos.OrderAPI.Repository;
using Microsoft.EntityFrameworkCore;

namespace MicroServicos.OrderAPI.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DbContextOptions<ApplicationDbContext> _context;
        public OrderRepository(DbContextOptions<ApplicationDbContext> context)
        {
            _context = context;
        }

        public async Task<bool> AddOrder(OrderHeader header)
        {
            if(header == null)
                return false;
            await using var _db = new ApplicationDbContext(_context);
            _db.Headers.Add(header);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task UpdateOrderStatus(long orderHeaderId, bool status)
        {
            await using var _db = new ApplicationDbContext(_context);
            var header = await _db.Headers.FirstOrDefaultAsync(o => o.Id == orderHeaderId);
            if(header != null)
            {
                header.PaymentStatus = status;
                await _db.SaveChangesAsync();
            }
        }
    }
}
