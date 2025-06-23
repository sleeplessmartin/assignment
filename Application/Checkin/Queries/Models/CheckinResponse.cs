using Application.Constants;

namespace Application.Checkin.Queries
{

    public class CheckinResponse
    {
        public long checkin_id { get; set; }
        public required string status { get; set; }
        public string? message { get; set; }
        public DateTime created_timestamp { get; set; }

        // NOTE to Oleg: In a real application, this would likely be a foreign key to a user table. 
        // A bigint/long datatype instead of varchar or string
        public required string user_id { get; set; } 
        public required string created_by_id { get; set; }
        public DateTime updated_timestamp { get; set; }
        public string updated_by_id { get; set; } = Users.SYSTEM_USER_ID;
    }
}