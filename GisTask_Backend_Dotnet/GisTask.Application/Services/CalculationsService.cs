using GisTask.Application.Dtos;
using GisTask.Application.Interfaces;

namespace GisTask.Application.Services;

public class CalculationsService : ICalculationsService
{
    public int CalculatePayabaleTime(IEnumerable<TripDto> trips)
    {
        var timeRanges = trips.Select(x => new DateRange(x.StartTime, x.EndTime)).ToList();
        timeRanges.Sort((x, y) => x.StartDate.CompareTo(y.StartDate));

        var mergedRanges = new List<DateRange>();
        foreach (var range in timeRanges)
        {
            if (!mergedRanges.Any())
            {
                mergedRanges.Add(range);
                continue;
            }
            var lastMergedRange = mergedRanges.Last();
            if (range.StartDate > lastMergedRange.EndDate)
            {
                mergedRanges.Add(range);
            }
            else if (range.EndDate > lastMergedRange.EndDate)
            {
                lastMergedRange = new DateRange(lastMergedRange.StartDate, range.EndDate);
            }
        }

        var PayableTimeMinutes = (int)mergedRanges.Sum(x => (x.EndDate - x.StartDate).TotalMinutes);
        return PayableTimeMinutes;
    }
}
