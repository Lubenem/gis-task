using GisTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GisTask.Domain;

public class AppContext : DbContext
{
    public AppContext(DbContextOptions<AppContext> options)
       : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    public DbSet<Driver> Drivers { get; set; }
    public DbSet<Trip> Trips { get; set; }
}