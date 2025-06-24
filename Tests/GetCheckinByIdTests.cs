using Application.Checkin.Queries;
using Infrastructure;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

public class GetCheckinByIdTests
{
    [Fact]
    public async Task GetCheckinByIdAsync_ReturnsCheckin_WhenExists()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<AssignmentContext>()
            .UseInMemoryDatabase(databaseName: "CheckinDb")
            .Options;

        var checkin = new CheckinModel
        {
            checkin_id = 1,
            status = "Happy",
            message = "Test",
            created_timestamp = System.DateTime.UtcNow,
            created_by_id = "user1",
            updated_timestamp = System.DateTime.UtcNow,
            updated_by_id = "user1",
            user_id = "user1"
        };

        using (var context = new AssignmentContext(options))
        {
            context.Checkins.Add(checkin);
            context.SaveChanges();
        }

        using (var context = new AssignmentContext(options))
        {
            var service = new GetCheckinById(context);

            // Act
            var result = await service.GetCheckinByIdAsync(1, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(checkin.checkin_id, result.checkin_id);
            Assert.Equal(checkin.status, result.status);
        }
    }

    [Fact]
    public async Task GetCheckinByIdAsync_Throws_WhenNotFound()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<AssignmentContext>()
            .UseInMemoryDatabase(databaseName: "CheckinDb_NotFound")
            .Options;

        using (var context = new AssignmentContext(options))
        {
            var service = new GetCheckinById(context);

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() =>
                service.GetCheckinByIdAsync(999, CancellationToken.None));
        }
    }
}