namespace Application.Checkin.Queries
{
    public interface IGetCheckinListByFilter
    {
        /// <summary>
        /// Retrieves a list of check-ins based on the provided filter criteria.
        /// </summary>
        /// <param name="filter">The filter criteria for retrieving check-ins.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation if needed.</param>
        /// <returns>A task that represents the asynchronous operation, containing a list of check-in responses.</returns>
        public Task<List<CheckinResponse>> GetCheckinListByFilterAsync(string filter, CancellationToken cancellationToken);
    }
}