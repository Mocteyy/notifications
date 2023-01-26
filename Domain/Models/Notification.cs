using Domain.Enums;

namespace Domain.Models
{
    public class Notification 
    {
        public int Id { get; set; } 
        public string Message { get; set; }
        public int UserId { get; set; }
        public Channels Channel { get; set; }
        public Categories Category { get; set; }

        public Notification(string message, int userId, Channels channel, Categories category)
        {
            Message  = message;
            UserId   = userId;
            Channel  = channel;
            Category = category;
        }
        
    }
}