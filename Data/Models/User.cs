using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Utils;
using Domain.Enums;
using Domain.Exceptions;
using Domain.Models;

namespace Data.Models
{
    [Table("User")]
    public class UserEF : DomainModel<User> {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        public List<NotificationEF> Notifications { get; set; } = new List<NotificationEF>();

        [Required]
        public string SuscribedCategories { get; set; }

        [Required]
        public string SuscribedChannels { get; set; }

        public User ToDomainModel()
        {

            var categories = this.SuscribedCategories.Split(",").ToList().Select(category => {
                Console.WriteLine(category);
                var codeCategory = Int16.Parse(category);
                return CategoryFunctions.GetCategoryFromCode(codeCategory);
            }).ToList();

            if(categories == null){
                throw new UnsupportedCategoryException();
            }

            var channels = this.SuscribedChannels.Split(",").ToList().Select(channel => {
                var code = Int16.Parse(channel);
                return ChannelFunctions.GetChannelFromCode(code);
            }).ToList();

            if(channels == null){
                throw new UnsupportedChannelException();
            }

            User domainUser = new User(FullName, Email, PhoneNumber, channels, categories);
            domainUser.Id = Id;

            return domainUser;

        }

        public UserEF(int id, string fullName, string email, string phoneNumber, string suscribedCategories, string suscribedChannels)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;
            SuscribedCategories = suscribedCategories;
            SuscribedChannels = suscribedChannels;
        }

        public bool IsSuscribed(Categories category)
        {
            var categories = this.SuscribedCategories.Split(",").ToList().Select(category => Int32.Parse(category)).ToList();
            Int32 categoryCode = -1;

            if(category == Categories.Sports){
                categoryCode = 0;
            } else if(category == Categories.Movies){
                categoryCode = 1;
            } else if (category == Categories.Videogames){
                categoryCode = 2;
            } else {
                throw new UnsupportedCategoryException();
            }

            var result = categories.ToList().Contains(categoryCode);
            
            return result;
        }
    }
}