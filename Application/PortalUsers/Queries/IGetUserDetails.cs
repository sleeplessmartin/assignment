using Application.PortalUsers.Queries.Models;

namespace Application.PortalUsers.Queries
{
    public interface IGetUserDetails
    {
        Task<PortalUserResponse> GetUserByIdAsync(PortalUserRequest request);
    }
}