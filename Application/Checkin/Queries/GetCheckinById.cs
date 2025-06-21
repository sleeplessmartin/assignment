using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Checkin.Queries
{
    public class GetCheckinById : IGetCheckinById
    {
        private readonly AssignmentContext _context;

        public GetCheckinById(AssignmentContext context)
        {
            _context = context;
        }

        public async Task<CheckinResponse> GetCheckinByIdAsync(long checkin_id, CancellationToken cancellationToken)
        {
            var checkin = await _context.Checkins
                .Where(c => c.checkin_id == checkin_id)
                .Select(c => new CheckinResponse
                {
                    checkin_id = c.checkin_id,
                    status = c.status,
                    message = c.message,
                    created_timestamp = c.created_timestamp,
                    user_id = c.user_id
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (checkin is null)
            {
                throw new KeyNotFoundException($"Check-in with ID {checkin_id} not found.");
            }

            return checkin;
        }
    }
}