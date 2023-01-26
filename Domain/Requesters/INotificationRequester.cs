using Domain.Dto;
using Domain.Models;

namespace Domain.Requesters
{
    public interface INotificationRequester 
    {
        Task BroadcastNotification(Message message);
        Task<List<Notification>> GetNotifications();
    }
}