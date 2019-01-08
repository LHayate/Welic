namespace UseFul.Uteis.UI
{
    public interface IMessage
    {
        void ProcessMessage(string message, MessageType type);
        Result ProcessDialog(string message);
    }
}