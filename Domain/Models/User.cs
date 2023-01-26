using Domain.Enums;

namespace Domain.Models 
{
    public class User 
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<Notification> Notifications { get; set; }
        public List<Channels> SuscribedChannels;
        public List<Categories> SuscribedCategories {get; set;}

        public User(string fullName, string email, string phoneNumber, List<Channels> channels, List<Categories> categories)
        {
            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;
            Notifications = new List<Notification>();
            SuscribedChannels = channels;
            SuscribedCategories = categories;
        }
    }
}