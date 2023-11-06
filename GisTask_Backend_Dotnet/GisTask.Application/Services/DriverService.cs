using GisTask.Application.Dtos;
using GisTask.Application.Interfaces;
using GisTask.Domain.Entities;
using AppContext = GisTask.Domain.AppContext;

namespace GisTask.Application.Services;

public class DriverService : IDriverService
{
    private readonly AppContext _dbContext;

    public DriverService(AppContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<DriverDto> GetDrivers()
    {
        return _dbContext.Drivers.Select(x => new DriverDto()
        {
            Id = x.Id,
            Name = x.Name,
            PayableTimeMinutes = x.PayableTimeMinutes,
        }).ToList();
    }

    public void AddDriver(DriverDto driverDto)
    {
        var driver = new Driver()
        {
            Name = driverDto.Name,
            PayableTimeMinutes = 0,
        };
        _dbContext.Drivers.Add(driver);
        _dbContext.SaveChanges();
    }

    public void RemoveDriver(int driverId)
    {
        var driver = _dbContext.Drivers.Find(driverId)
            ?? throw new Exception("Driver not found");
        _dbContext.Drivers.Remove(driver);
        _dbContext.SaveChanges();
    }

    public void CalculateDriversPayabaleTime(int driverId)
    {
        var driver = _dbContext.Drivers.Find(driverId) ?? throw new Exception("Driver not found");
        var trips = _dbContext.Trips.Where(x => x.DriverId == driverId).ToList();
        var payableTime = trips.Sum(x => (x.EndTime - x.StartTime).TotalMinutes);
        driver.PayableTimeMinutes = (int)payableTime;
        _dbContext.SaveChanges();
    }
}