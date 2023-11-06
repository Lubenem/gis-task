using GisTask.Application.Dtos;
using GisTask.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GisTask.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class TripController : ControllerBase
{
    private readonly ILogger<TripController> _logger;
    private readonly ITripService _tripService;
    const string ERROR_MESSAGE = "An error occurred";

    public TripController(ILogger<TripController> logger, ITripService tripService)
    {
        _logger = logger;
        _tripService = tripService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<TripDto>> GetTrips()
    {
        try
        {
            return Ok(_tripService.GetTrips());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ERROR_MESSAGE);
            return StatusCode(500, ERROR_MESSAGE);
        }
    }

    [HttpPost]
    public ActionResult AddTrip(TripDto trip)
    {
        try
        {
            _tripService.AddTrip(trip);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ERROR_MESSAGE);
            return StatusCode(500, ERROR_MESSAGE);
        }
    }

    [HttpPost]
    public ActionResult RemoveTrip(int tripId)
    {
        try
        {
            _tripService.RemoveTrip(tripId);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ERROR_MESSAGE);
            return StatusCode(500, ERROR_MESSAGE);
        }
    }
}
