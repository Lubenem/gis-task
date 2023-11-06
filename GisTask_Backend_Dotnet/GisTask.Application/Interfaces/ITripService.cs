using GisTask.Application.Dtos;

namespace GisTask.Application.Interfaces;

public interface ITripService
{
    IEnumerable<TripDto> GetTrips();
    void AddTrip(TripDto tripDto);
    void RemoveTrip(int tripId);
}