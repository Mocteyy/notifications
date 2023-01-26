using Data.Models;
using Domain.DataGateways;
using Domain.Enums;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class NotificationRepository : INotificationGateway
    {
        private readonly ApplicationContext context = new ApplicationContext();

        public async Task<List<Notification>> GetNotifications()
        {
            var notifications = await context.Notifications!.Select(notification => notification.ToDomainModel()).ToListAsync();
            return notifications;
        }

        public Task<Notification> SaveNotification(Notification notification)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Notification>> SaveNotificationRange(List<Notification> notifications)
        {
            var efNotifications = notifications.Select(notification => {
                return new NotificationEF(){
                    Category = notification.Category,
                    Channel = notification.Channel,
                    UserId = notification.UserId,
                    Message = notification.Message
                };
            });
            await this.context.Notifications!.AddRangeAsync(efNotifications);
            await context.SaveChangesAsync();
            var domainNotifications = efNotifications.Select(notification => notification.ToDomainModel());

            return domainNotifications.ToList();
        }
    }
}