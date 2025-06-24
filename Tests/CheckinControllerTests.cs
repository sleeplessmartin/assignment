using Xunit;
using Moq;
using API;
using Application.Checkin.Queries;
using Microsoft.AspNetCore.Mvc;

public class CheckInControllerTests
{
    [Fact]
    public async Task GetCheckIn_ReturnsOk_WithCheckinResponse()
    {
        // Arrange
        var mockGetCheckinById = new Mock<IGetCheckinById>();
        var mockCreateCheckin = new Mock<Application.Checkin.Commands.ICreateCheckin>();
        var mockUpdateCheckin = new Mock<Application.Checkin.Commands.IUpdateCheckin>();
        var mockGetCheckinListByFilter = new Mock<IGetCheckinListByFilter>();

        var expected = new CheckinResponse
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

        mockGetCheckinById
            .Setup(s => s.GetCheckinByIdAsync(1, It.IsAny<CancellationToken>()))
            .ReturnsAsync(expected);

        var controller = new CheckInController(
            mockGetCheckinListByFilter.Object,
            mockGetCheckinById.Object,
            mockCreateCheckin.Object,
            mockUpdateCheckin.Object
        );

        // Act
        var result = await controller.GetCheckIn(1, CancellationToken.None);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var actual = Assert.IsType<CheckinResponse>(okResult.Value);
        Assert.Equal(expected.checkin_id, actual.checkin_id);
        Assert.Equal(expected.status, actual.status);
    }
}