using Domain.Dto;
using Domain.Exceptions;
using Domain.Models;
using Domain.Requesters;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationRequester requester;

        public NotificationController(INotificationRequester requester)
        {
            this.requester = requester;
        }

        [HttpGet]
        public async Task<IActionResult> GetNotifications(){
            var result = await this.requester.GetNotifications();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> BroadcastNotification([FromBody] Message message)
        {
            try{
                await requester.BroadcastNotification(message);

                return new OkObjectResult("Notification has been sent");
                ;
            }catch(Exception e){
                if(typeof(NotificationException).IsInstanceOfType(e)){
                    return ManageNotificationException(e);
                } 
                return new BadRequestObjectResult(e.Message);
            }
        }

        private IActionResult ManageNotificationException(Exception e){
            if(typeof(UnsupportedChannelException).IsInstanceOfType(e))
            {
                return new BadRequestObjectResult(e.Message);
            } else if (typeof(UnsupportedCategoryException).IsInstanceOfType(e))
            {
                return new NotFoundObjectResult(e.Message);
            }
            else {
                return new BadRequestObjectResult(e.Message);
            }
        }
    }
}