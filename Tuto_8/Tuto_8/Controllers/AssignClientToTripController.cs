using Microsoft.AspNetCore.Mvc;
using Tuto_8.DTOs;
using Tuto_8.Interfaces;
using Tuto_8.Models;


namespace Tuto_8.Controllers;

[Route("api/trips")]
[ApiController]

public class AssignClientToTripController : ControllerBase
{
    private readonly IAssignClientToTripRepository _repository;

    public AssignClientToTripController(IAssignClientToTripRepository repository)
    {
        _repository = repository;
    }

    [HttpPost("{idTrip}/clients")]
    public async Task<ActionResult> AssignClientToTrip(int idTrip, [FromBody] AssignClientToTripDto dto)
    {
        try
        {
           
            var clientExists = await _repository.ClientExistsAsync(dto.Pesel);
            if (!clientExists)
            {
                return BadRequest("Client with this PESEL does not exist.");
            }

            
            var clientAlreadyRegistered = await _repository.ClientAlreadyRegisteredForTripAsync(dto.Pesel, idTrip);
            if (clientAlreadyRegistered)
            {
                return BadRequest("Client is already registered for this trip.");
            }

            
            var tripExistsAndIsFuture = await _repository.TripExistsAndFutureAsync(idTrip);
            if (!tripExistsAndIsFuture)
            {
                return BadRequest("Trip not found or it has already occurred.");
            }

            
            var clientTrip = new ClientTrip
            {
                Pesel = dto.Pesel,
                IdTrip = idTrip,
                PaymentDate = dto.PaymentDate,
                RegisteredAt = DateTime.Now
            };

            await _repository.AssignClientToTripAsync(clientTrip);

            return Ok("Client assigned to trip successfully.");
        }
        catch (Exception)
        {
            
            return StatusCode(500, "An error occurred while processing the request.");
        }
    }
}
