namespace ref_2;

class Program
{
    static void Main()
    {
        var broadcaster = new ConsoleNotificationBroadcaster();
        var violationProvider = new DefaultViolationDescriptionProvider();

        var notificationSystem = new GIBDDPostNotificationSystem(broadcaster, violationProvider);

        notificationSystem.SendMessageToAllPosts(
            1234,
            "Москва",
            true,
            DateTime.Now,
            new List<string> { "Пост_1", "Пост_2" },
            "Центральный отдел",
            "Дополнительная информация о происшествии");

        notificationSystem.ProcessTrafficViolation(1);
        notificationSystem.SendRegionalAlert(3, "Санкт-Петербург", new[] { "Адмиралтейский район", "Приморский район" });
    }
}