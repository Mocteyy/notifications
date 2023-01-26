using Domain.Enums;

namespace Domain.Dto
{
    public class Message 
    {
        public string Content { get; set; } = "";
        public Categories Category { get; set; }
    }
}