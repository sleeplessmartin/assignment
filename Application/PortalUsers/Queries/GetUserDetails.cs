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
        
        /// <summary>
        /// Retrieves user details by user ID and password. In a real application, this would typically involve a database query.
        /// </summary>
        /// <param name="request">The request containing user ID and password.</param>
        /// <returns>A task that represents the asynchronous operation, containing the user details.</returns>
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