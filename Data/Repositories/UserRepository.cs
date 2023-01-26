using Data.Models;
using Domain.DataGateways;
using Domain.Enums;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class UserRepository : IUserGateway
    {
        private List<UserEF> users = new List<UserEF>(){
                new UserEF(1, "David", "mail@mail.com", "1234567899", "0,1", "0"),
                new UserEF(2, "Daniel", "mail2@mail.com", "2234567899", "1,2", "1,0,2"
                ),
                new UserEF(3, "Jose", "mail3@mail.com", "2234567899", "0,1,2", "2,1"
                ),
        };
        private readonly ApplicationContext userContext = new ApplicationContext(); 
        public async Task<List<User>> FindSuscribedUsers(Categories category)
        {
            if(userContext.Users!.ToList().Count() == 0){
                await userContext.Users!.AddRangeAsync(users);
                await userContext.SaveChangesAsync();
            }

            var usersList = await userContext.Users!.ToListAsync();
            var suscribedUsers = usersList.Where(user => user.IsSuscribed(category)).Select(user => user.ToDomainModel()).ToList();
            return suscribedUsers;
        }

        public Task<User> FindUser(int userId)
        {
            throw new NotImplementedException();
        }
    }
}