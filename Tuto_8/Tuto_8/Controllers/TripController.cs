using Microsoft.AspNetCore.Mvc;
using Tuto_8.Interfaces;
using Tuto_8.DTOs;
using Tuto_8.Models;

namespace Tuto_8.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TripsController : ControllerBase
{
    private readonly ITripRepository _tripRepository;

    public TripsController(ITripRepository tripRepository)
    {
        _tripRepository = tripRepository;
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedList<GetTripDtos>>> GetTrips([FromQuery] int? page,
        [FromQuery] int pageSize = 10)
    {
        var currentPage = page ?? 1;

        var result = await _tripRepository.GetTripsAsync(currentPage, pageSize);
        return Ok(result);
    }
}
