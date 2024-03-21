using MicroServicos.MessageBus;

namespace MicroServicos.CartAPI.RabbitMQSender
{
    public interface IRabbitMQMessageSender
    {
        void SendMessage(BaseMessage baseMessage, string queuName);
    }
}
