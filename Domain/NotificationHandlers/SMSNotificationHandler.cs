namespace Domain.NotificationHandlers
{
    public class SMSNotificationHandler : NotificationHandler
    {
        public SMSNotificationHandler(string message): base(message){}

        public override async Task<bool> Send()
        {
            Console.WriteLine("Sent by SMS");
            return true;
        }
    }
}