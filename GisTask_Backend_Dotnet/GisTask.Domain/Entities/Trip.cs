namespace GisTask.Domain.Entities;

public class Trip
{
    public Guid Id { get; set; }
    public Guid? DriverId { get; set; } = null!;
    public Driver? Driver { get; set; } = null!;
    public int PassengerCount { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}