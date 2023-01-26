using Domain.Enums;
using Domain.Exceptions;
using Domain.NotificationHandlers;

namespace Domain.Utils 
{
    public class NotificationHandlerFactory : IHandlerFactory
    {
        public NotificationHandlerFactory()
        {
        }

        public NotificationHandler BuildHandler(Channels channel, string message){
            switch (channel){
                case Channels.PushNotification:
                    return new PushNotificationHandler(message);
                case Channels.Email:
                    return new EmailNotificationHandler(message);
                case Channels.SMS:
                    return new SMSNotificationHandler(message);
                default:
                    throw new UnsupportedChannelException();

            }
        }
    }
}