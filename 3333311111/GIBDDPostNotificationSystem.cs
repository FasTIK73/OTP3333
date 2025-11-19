namespace ref_2;

public class GIBDDPostNotificationSystem
{
    public static void NotifyPosts(string message)
    {
        Console.WriteLine("Сообщение для всех постов ГИБДД: {0}", message);
    }

    public string SendMessageToAllPosts(
        int postId,
        string location,
        bool isEmergency,
        DateTime timestamp,
        List<string> recipientsList,
        string senderName,
        string additionalInfo = null)
    {
        if (!CanSendMessage(isEmergency, recipientsList))
            return GetErrorMessage(isEmergency, recipientsList);

        SendMessagesToRecipients(postId, location, senderName, recipientsList);
        return "Сообщение успешно доставлено";
    }

    private bool CanSendMessage(bool isEmergency, List<string> recipientsList)
    {
        return !isEmergency && recipientsList.Count > 0 ||
               isEmergency && recipientsList.Count > 0;
    }

    private string GetErrorMessage(bool isEmergency, List<string> recipientsList)
    {
        if (isEmergency && recipientsList.Count <= 0)
            return "Отсутствуют получатели для экстренного уведомления!";

        return "Сообщение успешно отправлено.";
    }

    private void SendMessagesToRecipients(int postId, string location, string senderName, List<string> recipientsList)
    {
        foreach (var recipient in recipientsList)
        {
            SendMessageToRecipient(postId, location, senderName, recipient);
        }
    }

    private void SendMessageToRecipient(int postId, string location, string senderName, string recipient)
    {
        NotifyPosts($"Сообщение от поста №{postId}, местоположение: {location}. Отправитель: {senderName}");
    }

    public void HandleTrafficViolation(int violationCode)
    {
        string violationDescription = GetViolationDescription(violationCode);
        Console.WriteLine(violationDescription);
    }

    private string GetViolationDescription(int violationCode)
    {
        return violationCode switch
        {
            1 => "Превышение скорости",
            2 => "Проезд на красный свет",
            _ => "Неизвестное нарушение"
        };
    }

    public void SendSpecialAlert(int alertLevel, string region, string[] affectedAreas)
    {
        foreach (var area in affectedAreas)
        {
            SendAlertToArea(alertLevel, region, area);
        }
    }

    private void SendAlertToArea(int alertLevel, string region, string area)
    {
        NotifyPosts($"Спецуведомление уровня {alertLevel}: регион {region}, затронута область {area}");
    }
}