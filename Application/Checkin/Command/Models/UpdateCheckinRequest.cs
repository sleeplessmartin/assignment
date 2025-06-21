using Application.Constants;

namespace Application.Checkin.Command.Models
{
    public class UpdateCheckinRequest
    {
        public string status { get; set; } = null!;
        public string? message { get; set; }
        public DateTime updated_timestamp { get; set; } = DateTime.UtcNow;
        public long updated_by_id { get; set; } = Users.SYSTEM_USER_ID;

        // Additional properties can be added as needed
    }
}
// This class represents the request model for updating a check-in.
// It includes properties for user ID, status, message, and timestamp.
// The UserId is required, while Status and Message can be set to null.
// The Timestamp defaults to the current UTC time when a check-in is updated.
// The updated_by_id is set to a system user ID by default, which can be changed
// based on the context of the update operation.