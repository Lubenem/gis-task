using GisTask.Application.Dtos;

namespace GisTask.Application.Interfaces;

public interface ICalculationsService
{
    /// <summary>
    /// Calculates the total payable time for a driver in minutes.
    /// Overlapping trips are merged into one
    /// </summary>
    public int CalculatePayabaleTime(IEnumerable<TripDto> trips);
}