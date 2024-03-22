using Microsoft.EntityFrameworkCore;

namespace MicroServicos.Email.Model.Context
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext() {  }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) {  }
        public DbSet<EmailLog> Emails { get; set; }
    }
}
