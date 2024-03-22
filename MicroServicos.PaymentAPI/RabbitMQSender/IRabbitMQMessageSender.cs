using MicroServicos.MessageBus;

namespace MicroServicos.PaymentAPI.RabbitMQSender
{
    public interface IRabbitMQMessageSender
    {
        void SendMessage(BaseMessage baseMessage, string queuName);
    }
}
