using Application.Checkin.Commands.Models;
using Application.Checkin.Queries;

namespace Application.Checkin.Commands
{
    public interface ICreateCheckin
    {
        /// <summary>
        /// Creates a new check-in record.
        /// </summary>
        /// <param name="request">The request containing the details of the check-in to be created.</param>
        /// <returns>A task that represents the asynchronous operation, containing the created check-in response.</returns>
        public Task<CheckinResponse> CreateCheckinAsync(CreateCheckinRequest request);
    }
}