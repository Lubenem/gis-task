using GisTask.Application.Dtos;

namespace GisTask.Application.Interfaces;

public interface IDriverService
{
    IEnumerable<DriverDto> GetDrivers();
    void AddDriver(DriverDto driverDto);
    void RemoveDriver(int driverId);
}