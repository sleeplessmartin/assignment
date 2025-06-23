
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Checkin.Queries
{
    public class GetCheckinListByFilter : IGetCheckinListByFilter
    {
        private readonly AssignmentContext _context;

        public GetCheckinListByFilter(AssignmentContext context)
        {
            _context = context;
        }

        public async Task<List<CheckinResponse>> GetCheckinListByFilterAsync(string filter, CancellationToken cancellationToken)
        {
            var isDate = DateTime.TryParse(filter, out DateTime parsedDate);

            if (isDate)
            {
                // If the filter is a date, we can filter check-ins by date.
                return await _context.Checkins
                    .Where(c => c.created_timestamp.Date == parsedDate.Date)
                    .Select(c => new CheckinResponse
                    {
                        checkin_id = c.checkin_id,
                        status = c.status,
                        message = c.message,
                        created_timestamp = c.created_timestamp,
                        created_by_id = c.created_by_id,
                        updated_timestamp = c.updated_timestamp,
                        updated_by_id = c.updated_by_id,
                        user_id = c.user_id
                    })
                    .OrderByDescending(c => c.created_timestamp)
                    .ToListAsync(cancellationToken);
            }

            return await _context.Checkins
                    .Where(c => c.user_id.Contains(filter))
                    .Select(c => new CheckinResponse
                    {
                        checkin_id = c.checkin_id,
                        status = c.status,
                        message = c.message,
                        created_timestamp = c.created_timestamp,
                        created_by_id = c.created_by_id,
                        updated_timestamp = c.updated_timestamp,
                        updated_by_id = c.updated_by_id,
                        user_id = c.user_id
                    })
                    .OrderByDescending(c => c.created_timestamp)
                    .ToListAsync(cancellationToken);
        }
    }
}