namespace GisTask.Domain.Entities;

public class Driver
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    public ICollection<Trip> Trips { get; set; } = new List<Trip>();
    public int PayableTimeMinutes { get; set; }
}