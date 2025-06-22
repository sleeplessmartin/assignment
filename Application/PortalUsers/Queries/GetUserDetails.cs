using Application.PortalUsers.Queries.Models;

namespace Application.PortalUsers.Queries
{
    public class GetUserDetails : IGetUserDetails
    {
        private readonly List<PortalUser> _users;
        public GetUserDetails(List<PortalUser> users)
        {
            _users = users ?? throw new ArgumentNullException(nameof(users));
        }

        public Task<PortalUserResponse> GetUserByIdAsync(PortalUserRequest request)
        {
            var user = _users.FirstOrDefault(u => u.user_id == request.user_id && u.password == request.password);

            if (user is null)
            {
                throw new KeyNotFoundException($"User with ID {request.user_id} not found.");
            }

            var result = new PortalUserResponse
            {
                user_id = user.user_id,
                full_name = user.full_name
            };

            return Task.FromResult(result);
        }
    }
}