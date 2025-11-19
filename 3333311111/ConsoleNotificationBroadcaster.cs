namespace ref_2;
public class ConsoleNotificationBroadcaster : INotificationBroadcaster
{
    public void BroadcastToAllPosts(string message)
    {
        Console.WriteLine("Сообщение для всех постов ГИБДД: {0}", message);
    }
}
