using GisTask.Application.Dtos;
using GisTask.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GisTask.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class DriverController : ControllerBase
{
    private readonly ILogger<DriverController> _logger;
    private readonly IDriverService _driverService;
    const string ERROR_MESSAGE = "An error occurred";

    public DriverController(ILogger<DriverController> logger, IDriverService DriverService)
    {
        _logger = logger;
        _driverService = DriverService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<DriverDto>> GetDrivers()
    {
        try
        {
            return Ok(_driverService.GetDrivers());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ERROR_MESSAGE);
            return StatusCode(500, ERROR_MESSAGE);
        }
    }

    [HttpPost]
    public ActionResult AddDriver(DriverDto Driver)
    {
        try
        {
            _driverService.AddDriver(Driver);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ERROR_MESSAGE);
            return StatusCode(500, ERROR_MESSAGE);
        }
    }

    [HttpPost]
    public ActionResult RemoveDriver(int DriverId)
    {
        try
        {
            _driverService.RemoveDriver(DriverId);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ERROR_MESSAGE);
            return StatusCode(500, ERROR_MESSAGE);
        }
    }
}
