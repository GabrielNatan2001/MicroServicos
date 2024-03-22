using Microsoft.EntityFrameworkCore;

namespace MicroServicos.OrderAPI.Model.Context
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext() {  }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) {  }

        public DbSet<OrderHeader> Headers { get; set; }
        public DbSet<OrderDetail> Details { get; set; }
    }
}
