using GisTask.Application.Dtos;
using GisTask.Application.Interfaces;
using GisTask.Domain.Entities;
using AppContext = GisTask.Domain.AppContext;

namespace GisTask.Application.Services;

public class TripService : ITripService
{
    private readonly AppContext _dbContext;
    private readonly ICalculationsService _calculationsService;

    public TripService(AppContext dbContext, ICalculationsService calculationsService)
    {
        _dbContext = dbContext;
        _calculationsService = calculationsService;
    }

    public IEnumerable<TripDto> GetTrips()
    {
        return _dbContext.Trips.Select(x => new TripDto()
        {
            Id = x.Id,
            DriverId = x.DriverId,
            PassengerCount = x.PassengerCount,
            StartTime = x.StartTime,
            EndTime = x.EndTime,
        }).ToList();
    }

    public IEnumerable<TripDto> GetTripsByDriverId(int driverId)
    {
        return _dbContext.Trips
            .Where(x => x.DriverId == driverId)
            .Select(x => new TripDto()
            {
                Id = x.Id,
                DriverId = x.DriverId,
                PassengerCount = x.PassengerCount,
                StartTime = x.StartTime,
                EndTime = x.EndTime,
            }).ToList();
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

        if (trip.DriverId is not null)
        {
            CalculateDriversPayabaleTime(tripDto.DriverId.Value);
        }
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

    private void CalculateDriversPayabaleTime(int driverId)
    {
        var driver = _dbContext.Drivers.Find(driverId) ?? throw new Exception("Driver not found");
        var trips = GetTripsByDriverId(driverId);
        driver.PayableTimeMinutes = _calculationsService.CalculatePayabaleTime(trips);
        _dbContext.SaveChanges();
    }
}