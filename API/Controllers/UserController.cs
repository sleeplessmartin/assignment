using Microsoft.AspNetCore.Mvc;
using Application.PortalUsers.Queries;
using Application.PortalUsers.Queries.Models;
namespace API
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly IGetUserDetails _igud;

        public UserController(IGetUserDetails igud)
        {
            _igud = igud;
        }

        [HttpPost]
        public async Task<ActionResult<PortalUserResponse>> PostCheckIn([FromBody] PortalUserRequest user)
        {
            if (user is null)
            {
                return BadRequest("User data is required.");
            }

            var result = await _igud.GetUserByIdAsync(user);

            return Ok(result);
        }
    }
}
