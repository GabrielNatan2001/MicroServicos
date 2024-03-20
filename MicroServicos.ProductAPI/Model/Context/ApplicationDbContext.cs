using Microsoft.EntityFrameworkCore;

namespace MicroServicos.ProductAPI.Model.Context
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext() {  }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) {  }

        public DbSet<Product> Products { get; set; }
    }
}
