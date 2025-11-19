namespace ref_2;
public abstract class BaseNotificationSystem
{
    protected static void NotifyPosts(string message)
    {
        Console.WriteLine("Сообщение для всех постов ГИБДД: {0}", message);
    }
    protected bool CanSendMessage(bool isEmergency, List<string> recipientsList)
    {
        return !isEmergency && recipientsList.Count > 0 ||
               isEmergency && recipientsList.Count > 0;
    }
    protected string GetErrorMessage(bool isEmergency, List<string> recipientsList)
    {
        if (isEmergency && recipientsList.Count <= 0)
            return "Отсутствуют получатели для экстренного уведомления!";
        return "Сообщение успешно отправлено.";
    }
    protected void SendMessagesToRecipients(int postId, string location, string senderName, List<string> recipientsList)
    {
        foreach (var recipient in recipientsList)
        {
            SendMessageToRecipient(postId, location, senderName, recipient);
        }
    }
    protected void SendMessageToRecipient(int postId, string location, string senderName, string recipient)
    {
        NotifyPosts($"Сообщение от поста №{postId}, местоположение: {location}. Отправитель: {senderName}");
    }
}