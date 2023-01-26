using Domain.Enums;
using Domain.Models;

namespace Domain.DataGateways
{
    public interface IUserGateway 
    {
        Task<User> FindUser(int userId); 
        Task<List<User>> FindSuscribedUsers(Categories category);
    }
}