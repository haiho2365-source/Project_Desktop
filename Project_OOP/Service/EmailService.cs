using Project_OOP;

public class EmailService : INotificationService
{
    public void SendNotification(Person recipient, string message)
    {
        string logMessage = "Đã gửi Email tới: " + recipient.Email + " - Nội dung: " + message;
        Logger.Log(logMessage);
    }
}