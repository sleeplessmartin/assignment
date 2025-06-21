using Application.Checkin.Queries;
using Infrastructure.Models;
using Infrastructure;
using Application.Checkin.Command.Models;

namespace Application.Checkin.Command
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
                user_id= request.user_id,
                created_timestamp = request.created_timestamp,
                status = request.status,
                message = request.message
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