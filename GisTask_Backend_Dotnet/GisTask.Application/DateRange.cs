namespace GisTask.Application;

public class DateRange
{
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }

    public DateRange(DateTime startDate, DateTime endDate)
    {
        if (startDate >= endDate)
        {
            throw new ArgumentException("Start date must be less than end date");
        }

        StartDate = startDate;
        EndDate = endDate;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        var other = (DateRange)obj;
        var equals = StartDate == other.StartDate && EndDate == other.EndDate;
        return equals;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(StartDate, EndDate);
    }

    public bool Includes(DateTime date)
    {
        return (date >= StartDate) && (date < EndDate);
    }
}
