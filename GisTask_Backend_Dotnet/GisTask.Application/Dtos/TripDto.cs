namespace GisTask.Application.Dtos;

public class TripDto
{
    public int Id { get; set; }
    public int? DriverId { get; set; } = null!;
    public int PassengerCount { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}