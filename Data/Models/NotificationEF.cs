using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;
using Domain.Models;

namespace Data.Models {
    public class NotificationEF : DomainModel<Notification> {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Message { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public Categories Category { get; set; }
        
        public Channels Channel { get; set; }

        public Notification ToDomainModel()
        {
            var notification = new Notification(this.Message!, this.UserId, this.Channel, this.Category);
            notification.Id = Id;
            return notification;
        }
    }
}