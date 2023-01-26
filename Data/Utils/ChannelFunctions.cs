using Domain.Enums;
using Domain.Exceptions;

namespace Data.Utils 
{
    public class ChannelFunctions 
    {
        public static Channels GetChannelFromCode(int code)
        {
            switch(code){
                case 0:
                    return Channels.PushNotification;
                case 1:
                    return Channels.Email;
                case 2:
                    return Channels.SMS;
                default:
                    throw new UnsupportedChannelException();
            }
        }
    }
}