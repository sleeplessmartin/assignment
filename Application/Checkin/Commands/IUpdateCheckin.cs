using Application.Checkin.Commands.Models;
using Application.Checkin.Queries;

namespace Application.Checkin.Commands
{
    public interface IUpdateCheckin
    {
        /// <summary>
        /// Updates an existing check-in record.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<CheckinResponse> UpdateCheckinAsync(UpdateCheckinRequest request, long checkin_id);
    }
}