using Microsoft.EntityFrameworkCore;

namespace MicroServicos.CartAPI.Model.Context
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext() {  }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) {  }

        public DbSet<Product> Products { get; set; }
        public DbSet<CartHeader> CartHeaders { get; set; }
        public DbSet<CartDetail> CartDetails { get; set; }
    }
}
