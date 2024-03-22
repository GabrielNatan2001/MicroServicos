using MicroServicos.Email.Messages;
using MicroServicos.Email.Model;

namespace MicroServicos.Email.Repository
{
    public interface IEmailRepository
    {
        Task LogEmail(UpdatePaymentResultMessage message);
    }
}
