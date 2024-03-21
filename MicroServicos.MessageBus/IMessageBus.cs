namespace MicroServicos.MessageBus
{
    public interface IMessageBus
    {
        Task PublicMessage(BaseMessage message, string queuName);
    }
}