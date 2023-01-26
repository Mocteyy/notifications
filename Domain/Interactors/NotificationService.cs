using Domain.DataGateways;
using Domain.Dto;
using Domain.Models;
using Domain.Requesters;
using Domain.Utils;

namespace Domain.Interactors
{
    public class NotificationService : INotificationRequester
    {
        private readonly INotificationGateway notificationGateway;
        private readonly IUserGateway userGateway;
        private readonly NotificationHandlerFactory handlerFactory;

        public NotificationService(
            INotificationGateway notificationGateway, 
            IUserGateway userGateway, 
            NotificationHandlerFactory handlerFactory
        )
        {
            this.notificationGateway = notificationGateway;
            this.userGateway = userGateway;
            this.handlerFactory = handlerFactory;
        }

        public async Task BroadcastNotification(Message message)
        {
            var notifications = await BuildNotifications(message);
            await notificationGateway.SaveNotificationRange(notifications);
            SendNotifications(notifications);
        }

        public Task<List<Notification>> GetNotifications()
        {
            var notifications = this.notificationGateway.GetNotifications();
            return notifications;
        }

        private async Task<List<Notification>> BuildNotifications(Message message)
        {
            var suscribedUsers = await this.userGateway.FindSuscribedUsers(message.Category);
            List<Notification> notificationsToSave = new List<Notification>();

            suscribedUsers.ForEach(user => {
                user.SuscribedChannels.ForEach(channel => {
                    var notification = new Notification(
                        message: message.Content, 
                        userId: user.Id,
                        channel: channel,
                        category: message.Category
                    );
                    notificationsToSave.Add(notification);
                });  
            });

            return notificationsToSave;
        }

        private void SendNotifications(List<Notification> notifications)
        {
            notifications.ForEach(async notification => {
                var handler = handlerFactory.BuildHandler(notification.Channel, notification.Message);
                await handler.Send();
            });
        }
    }
}