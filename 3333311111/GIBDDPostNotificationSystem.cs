namespace ref_2;

public class GIBDDPostNotificationSystem : BaseNotificationSystem
{
    private readonly IViolationDescriptionProvider _violationDescriptionProvider;

    public GIBDDPostNotificationSystem(
        INotificationBroadcaster broadcaster,
        IViolationDescriptionProvider violationDescriptionProvider = null)
        : base(broadcaster)
    {
        _violationDescriptionProvider = violationDescriptionProvider ?? new DefaultViolationDescriptionProvider();
    }

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
        string violationDescription = _violationDescriptionProvider.GetViolationDescription(violationCode);
        Console.WriteLine(violationDescription);
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
        _broadcaster.BroadcastToAllPosts($"Спецуведомление уровня {alertLevel}: регион {region}, затронута область {area}");
    }
}