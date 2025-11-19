namespace ref_2;
public abstract class BaseNotificationSystem
{
    protected readonly INotificationBroadcaster _broadcaster;

    protected BaseNotificationSystem(INotificationBroadcaster broadcaster)
    {
        _broadcaster = broadcaster;
    }

    protected bool CanSendMessage(bool isEmergency, List<string> recipients)
    {
        return !isEmergency && recipients.Count > 0 ||
               isEmergency && recipients.Count > 0;
    }

    protected string GetErrorMessage(bool isEmergency, List<string> recipients)
    {
        if (isEmergency && recipients.Count <= 0)
            return "Отсутствуют получатели для экстренного уведомления!";

        return "Сообщение успешно отправлено.";
    }

    protected void SendToAllRecipients(int postId, string location, string sender, List<string> recipients)
    {
        foreach (var recipient in recipients)
        {
            SendToRecipient(postId, location, sender, recipient);
        }
    }

    protected void SendToRecipient(int postId, string location, string sender, string recipient)
    {
        _broadcaster.BroadcastToAllPosts($"Сообщение от поста №{postId}, местоположение: {location}. Отправитель: {sender}");
    }
}