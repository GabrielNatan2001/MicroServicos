using MicroServicos.MessageBus;

namespace MicroServicos.OrderAPI.RabbitMQSender
{
    public interface IRabbitMQMessageSender
    {
        void SendMessage(BaseMessage baseMessage, string queuName);
    }
}
