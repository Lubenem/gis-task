using GisTask.Application.Dtos;
using GisTask.Domain.Entities;
using AppContext = GisTask.Domain.AppContext;

namespace GisTask.Application;

public class TripService
{
    private readonly AppContext _dbContext;

    public TripService(AppContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void AddTrip(TripDto tripDto)
    {
        var trip = new Trip()
        {
            DriverId = tripDto.DriverId,
            PassengerCount = tripDto.PassengerCount,
            StartTime = tripDto.StartTime,
            EndTime = tripDto.EndTime,
        };
        _dbContext.Trips.Add(trip);
        _dbContext.SaveChanges();

        CalculateDriversPayabaleTime(tripDto.DriverId);
    }

    public void RemoveTrip(int tripId)
    {
        var trip = _dbContext.Trips.Find(tripId) ?? throw new Exception("Trip not found");
        _dbContext.Trips.Remove(trip);
        _dbContext.SaveChanges();

        if (trip.DriverId is not null)
        {
            CalculateDriversPayabaleTime(trip.DriverId.Value);
        }
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
