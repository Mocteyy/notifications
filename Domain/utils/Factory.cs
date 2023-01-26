using Domain.Enums;
using Domain.NotificationHandlers;

namespace Domain.Utils
{
    public interface IHandlerFactory 
    {
        NotificationHandler BuildHandler(Channels channel, string message);
    }
}