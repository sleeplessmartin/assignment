namespace Application.PortalUsers.Queries.Models
{
    public class PortalUser
    {
        public required string user_id { get; set; }
        public required string full_name { get; set; }
        public required string password { get; set; }
    }
}