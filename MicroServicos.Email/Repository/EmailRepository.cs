using MicroServicos.Email.Model.Context;
using MicroServicos.Email.Model;
using MicroServicos.Email.Repository;
using Microsoft.EntityFrameworkCore;
using MicroServicos.Email.Messages;

namespace MicroServicos.Email.Repository
{
    public class EmailRepository : IEmailRepository
    {
        private readonly ApplicationDbContext _context;
        public EmailRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task LogEmail(UpdatePaymentResultMessage message)
        {
            EmailLog email = new EmailLog
            {
                Email = message.Email,
                SentDate = DateTime.Now,
                Log = $"order - {message.OrderId} has been created successfully"
            };

            _context.Emails.Add(email);
            await _context.SaveChangesAsync();
        }
    }
}
