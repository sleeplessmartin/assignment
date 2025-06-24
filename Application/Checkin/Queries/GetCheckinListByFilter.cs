
using Infrastructure;
using Infrastructure.Models;
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

            IQueryable<CheckinModel> query;

            if (isDate)
            {
                parsedDate = DateTime.SpecifyKind(parsedDate.Date, DateTimeKind.Utc);
                var nextDay = parsedDate.AddDays(1);
                query = _context.Checkins
                    .Where(c => c.created_timestamp >= parsedDate && c.created_timestamp < nextDay);
            }
            else
            {
                if (filter == string.Empty)
                {
                    query = _context.Checkins;

                }
                else
                {
                    query = _context.Checkins
                    .Where(c => c.user_id.Contains(filter));
                }
                
            }

            return await query
                .OrderByDescending(c => c.created_timestamp)
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
                .ToListAsync(cancellationToken);
        }
    }
}