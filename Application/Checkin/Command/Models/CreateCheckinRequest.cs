using Application.Constants;

namespace Application.Checkin.Command.Models
{
    public class CreateCheckinRequest
    {
        public long user_id { get; set; }
        public string status { get; set; } = null!;
        public string? message { get; set; }
        public DateTime created_timestamp { get; set; } = DateTime.UtcNow;
        public long created_by_id { get; set; } = Users.SYSTEM_USER_ID;
        public DateTime updated_timestamp { get; set; } = DateTime.UtcNow;
        public long updated_by_id { get; set; } = Users.SYSTEM_USER_ID;
        
        // Additional properties can be added as needed
    }
}
// This class represents the request model for creating a check-in.
// It includes properties for user ID, status, message, and timestamp.
// The UserId is required, while Status and Message can be set to null.
// The Timestamp defaults to the current UTC time when a new check-in is created.