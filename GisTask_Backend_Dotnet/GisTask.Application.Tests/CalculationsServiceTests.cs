using GisTask.Application.Dtos;
using GisTask.Application.Services;

namespace GisTask.Application.Tests;

public class CalculationsServiceTests
{
    [Fact]
    public void CalculatePayableTime_WithOverlappings_ShouldReturnCorrectTotalTime()
    {
        // Arrange
        var trips = new List<TripDto>
        {
            new() { StartTime = new DateTime(2023, 11, 19, 9, 0, 0), EndTime = new DateTime(2023, 11, 19, 10, 0, 0) },
            new() { StartTime = new DateTime(2023, 11, 19, 10, 30, 0), EndTime = new DateTime(2023, 11, 19, 12, 0, 0) },
            new() { StartTime = new DateTime(2023, 11, 19, 9, 30, 0), EndTime = new DateTime(2023, 11, 19, 11, 0, 0) },
            new() { StartTime = new DateTime(2023, 11, 19, 9, 10, 0), EndTime = new DateTime(2023, 11, 19, 9, 20, 0) }
        };
        var calculationsService = new CalculationsService();
        var expectedTotalTime = 180; // Expected total time in minutes

        // Act
        var actualTotalTime = calculationsService.CalculatePayabaleTime(trips);

        // Assert
        Assert.Equal(expectedTotalTime, actualTotalTime);
    }

    [Fact]
    public void CalculatePayableTime_WithoutOverlappings_ShouldReturnCorrectTotalTime()
    {
        // Arrange
        var trips = new List<TripDto>
        {
            new() { StartTime = new DateTime(2023, 11, 19, 8, 0, 0), EndTime = new DateTime(2023, 11, 19, 9, 0, 0) },
            new() { StartTime = new DateTime(2023, 11, 19, 10, 0, 0), EndTime = new DateTime(2023, 11, 19, 11, 0, 0) },
            new() { StartTime = new DateTime(2023, 11, 20, 10, 0, 0), EndTime = new DateTime(2023, 11, 20, 11, 0, 0) },
            new() { StartTime = new DateTime(2023, 11, 20, 20, 0, 0), EndTime = new DateTime(2023, 11, 20, 20, 30, 0) }
        };
        var calculationsService = new CalculationsService();
        var expectedTotalTime = 210; // Expected total time in minutes

        // Act
        var actualTotalTime = calculationsService.CalculatePayabaleTime(trips);

        // Assert
        Assert.Equal(expectedTotalTime, actualTotalTime);
    }

    [Fact]
    public void CalculatePayableTime_WithIntentionalFailure_ShouldNotEqual()
    {
        // Arrange
        var trips = new List<TripDto>
        {
            new() { StartTime = new DateTime(2023, 11, 19, 9, 0, 0), EndTime = new DateTime(2023, 11, 19, 10, 0, 0) },
            new() { StartTime = new DateTime(2023, 11, 19, 10, 30, 0), EndTime = new DateTime(2023, 11, 19, 12, 0, 0) },
            new() { StartTime = new DateTime(2023, 11, 19, 9, 30, 0), EndTime = new DateTime(2023, 11, 19, 11, 0, 0) },
            new() { StartTime = new DateTime(2023, 11, 19, 9, 10, 0), EndTime = new DateTime(2023, 11, 19, 9, 20, 0) }
        };
        var calculationsService = new CalculationsService();
        var incorrectTotalTime = 30; // Intentionally incorrect total time in minutes

        // Act
        var actualTotalTime = calculationsService.CalculatePayabaleTime(trips);

        // Assert
        Assert.NotEqual(incorrectTotalTime, actualTotalTime);
    }
}
