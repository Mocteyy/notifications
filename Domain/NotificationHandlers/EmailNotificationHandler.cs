namespace Domain.NotificationHandlers
{
    public class EmailNotificationHandler : NotificationHandler
    {
        public EmailNotificationHandler(string message) : base(message){}

        public override async Task<bool> Send()
        {
            Console.WriteLine("Sent by Email");
            return true;
        }
    }
}