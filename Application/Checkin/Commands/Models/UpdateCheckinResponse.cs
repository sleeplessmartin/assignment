using Application.Constants;

namespace Application.Checkin.Commands.Models
{
    public class UpdateCheckinResponse
    {
        public string status { get; set; } = null!;
        public string? message { get; set; }
        public DateTime updated_timestamp { get; set; } = DateTime.UtcNow;

        // Additional properties can be added as needed
    }
}