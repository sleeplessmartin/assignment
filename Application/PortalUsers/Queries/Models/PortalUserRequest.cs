namespace Application.PortalUsers.Queries.Models
{
    public class PortalUserRequest
    {
        public required string user_id { get; set; }
        public required string password { get; set; }
    }
}