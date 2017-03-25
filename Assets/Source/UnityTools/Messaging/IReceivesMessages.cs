using Assets.Source.Messaging.Messages;

namespace Assets.Source.Messaging
{
    public interface IReceivesMessages<T> where T : GameMessage
    {
        void HandleMessage(T message);
    }
}