using Domain.Models;

namespace Domain.DataGateways
{
    public interface INotificationGateway
    {
        Task<Notification> SaveNotification(Notification notification);
        Task<List<Notification>> SaveNotificationRange(List<Notification> notifications);
        Task<List<Notification>> GetNotifications();
    }
}