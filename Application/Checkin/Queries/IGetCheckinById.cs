namespace Application.Checkin.Queries
{
    public interface IGetCheckinById
    {
        public Task<CheckinResponse> GetCheckinByIdAsync(long checkin_id, CancellationToken cancellationToken);
    }
}