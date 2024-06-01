using Microsoft.AspNetCore.Mvc;
using Tuto_8.Interfaces;

namespace Tuto_8.Controllers;

[Route("api/[controller]")]
[ApiController]

public class ClientController : ControllerBase
{
    private readonly IClientRepository _clientRepository;

    public ClientController(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    [HttpDelete("{idClient}")]
    public async Task<ActionResult> DeleteClient(int idClient)
    {
       
        var clientHasTrips = await _clientRepository.ClientHasTripsAsync(idClient);
        if (clientHasTrips)
        {
            return BadRequest("Client has assigned trips and cannot be deleted.");
        }

       
        await _clientRepository.DeleteClientAsync(idClient);
        return NoContent();
    }
}

