using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GisTask.Domain.Entities;

public class Trip
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int? DriverId { get; set; } = null!;
    public Driver? Driver { get; set; } = null!;
    public int PassengerCount { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}