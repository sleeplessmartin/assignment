using Application.Checkin.Command.Models;
using Application.Checkin.Queries;

namespace Application.Checkin.Command
{
    public interface IUpdateCheckin
    {
        /// <summary>
        /// Updates an existing check-in record.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<UpdateCheckinResponse> UpdateCheckinAsync(UpdateCheckinRequest request, long checkin_id);
    }
}