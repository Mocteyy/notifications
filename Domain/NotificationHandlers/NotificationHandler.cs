namespace Domain.NotificationHandlers 
{
    public abstract class NotificationHandler 
    {
        public string Message { get; set; }
        public abstract Task<bool> Send();
        protected NotificationHandler(string message)
        {
            Message = message;
        }
    }
}