using GisTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GisTask.Domain;

public class AppContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=GisTask;Trusted_Connection=True;TrustServerCertificate=Yes;");
    }

    public DbSet<Driver> Drivers { get; set; }
    public DbSet<Trip> Trips { get; set; }
}