using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GisTask.Domain.Entities;

public class Driver
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public ICollection<Trip> Trips { get; set; } = new List<Trip>();
    public int PayableTimeMinutes { get; set; }
}