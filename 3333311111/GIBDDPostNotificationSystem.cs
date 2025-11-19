namespace ref_2;

public class GIBDDPostNotificationSystem : BaseNotificationSystem
{
    public string SendMessageToAllPosts(
        int postId,
        string location,
        bool isEmergency,
        DateTime timestamp,
        List<string> recipients,
        string sender,
        string additionalInfo = null)
    {
        if (!CanSendMessage(isEmergency, recipients))
            return GetErrorMessage(isEmergency, recipients);

        SendToAllRecipients(postId, location, sender, recipients);
        return "Сообщение успешно доставлено";
    }

    public void ProcessTrafficViolation(int violationCode)
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

    public void SendRegionalAlert(int alertLevel, string region, string[] affectedAreas)
    {
        foreach (var area in affectedAreas)
        {
            SendAlertToArea(alertLevel, region, area);
        }
    }

    private void SendAlertToArea(int alertLevel, string region, string area)
    {
        BroadcastToAllPosts($"Спецуведомление уровня {alertLevel}: регион {region}, затронута область {area}");
    }
}