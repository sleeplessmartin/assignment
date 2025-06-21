using Application.Checkin.Queries;
using Infrastructure.Models;
using Infrastructure;
using Application.Checkin.Command.Models;

namespace Application.Checkin.Command
{
    public class UpdateCheckin : IUpdateCheckin
    {
        private readonly AssignmentContext _context;

        public UpdateCheckin(AssignmentContext context)
        {
            _context = context;
        }

        public async Task<UpdateCheckinResponse> UpdateCheckinAsync(UpdateCheckinRequest request, long checkin_id)
        {
            var checkin = _context.Checkins.FirstOrDefault(c => c.checkin_id == checkin_id);

            if (checkin is null)
            {
                throw new KeyNotFoundException($"Check-in with ID {checkin_id} not found.");
            }

            checkin.status = request.status;
            checkin.message = request.message;
            checkin.updated_by_id = request.updated_by_id;
            checkin.updated_timestamp = DateTime.UtcNow;

            _context.Checkins.Update(checkin);

            await _context.SaveChangesAsync();

            return new UpdateCheckinResponse
            {
                updated_timestamp = checkin.updated_timestamp,
                status = checkin.status,
                message = checkin.message
            };
        }
    }
}