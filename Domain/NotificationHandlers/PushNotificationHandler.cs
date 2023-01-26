namespace Domain.NotificationHandlers
{
    public class PushNotificationHandler : NotificationHandler
    {
        public PushNotificationHandler(string message) : base(message){}

        public override async Task<bool> Send()
        {
            return true;
        }
    }
}