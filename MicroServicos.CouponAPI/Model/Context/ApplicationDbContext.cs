using Microsoft.EntityFrameworkCore;

namespace MicroServicos.CouponAPI.Model.Context
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext() {  }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) {  }

        public DbSet<Coupon> Coupons { get; set; }
    }
}
