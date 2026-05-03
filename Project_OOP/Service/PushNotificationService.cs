using Project_OOP;

public class PushNotificationService : INotificationService
{
    public void SendNotification(Person recipient, string message)
    {
        string logMessage = "Đã gửi Push Notification tới thiết bị của: " + recipient.FullName + " - Nội dung: " + message;
        Logger.Log(logMessage);
    }
}