using Application.Checkin.Queries;
using Infrastructure.Models;
using Infrastructure;
using Application.Constants;
using Application.Checkin.Commands.Models;

namespace Application.Checkin.Commands
{
    public class CreateCheckin : ICreateCheckin
    {
        private readonly AssignmentContext _context;

        public CreateCheckin(AssignmentContext context)
        {
            _context = context;
        }

        public async Task<CheckinResponse> CreateCheckinAsync(CreateCheckinRequest request)
        {
            var checkin = new CheckinModel
            {
                created_by_id = request.created_by_id,
                user_id = request.user_id,
                created_timestamp = DateTime.UtcNow,
                status = request.status,
                message = request.message,
                updated_by_id = Users.SYSTEM_USER_ID, // Default to system user
                updated_timestamp = DateTime.UtcNow
            };

            _context.Checkins.Add(checkin);

            await _context.SaveChangesAsync();
            
            return new CheckinResponse
            {
                checkin_id = checkin.checkin_id,
                user_id = checkin.user_id,
                created_timestamp = checkin.created_timestamp,
                created_by_id = checkin.created_by_id,
                updated_by_id = checkin.updated_by_id,
                updated_timestamp = checkin.updated_timestamp,
                status = checkin.status,
                message = checkin.message
            };
        }
    }
}