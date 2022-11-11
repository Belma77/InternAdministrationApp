using Backend.Models.Enums;

namespace Backend.Dtos
{
    public class AppUpdateStatus
    {
        public int ApplicationId { get; set; }
        public Status Status { get; set; }
        
    }
}
