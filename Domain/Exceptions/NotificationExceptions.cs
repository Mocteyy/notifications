namespace Domain.Exceptions
{
    public class NotificationException : Exception 
    {
        public NotificationException(string message) : base(message) {}
    }

    public class UnsupportedCategoryException : NotificationException
    {
        public UnsupportedCategoryException() : base("Provided category not found."){}
    }

    public class UnsupportedChannelException : NotificationException
    {
        public UnsupportedChannelException() : base("Provided channel not supported.")
        {
        }
    }
}