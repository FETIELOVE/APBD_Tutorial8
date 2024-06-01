using Microsoft.EntityFrameworkCore;
using Tuto_8.Interfaces;
using Tuto_8.Models;

namespace Tuto_8.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly MasterContext _context;

    public ClientRepository(MasterContext context)
    {
        _context = context;
    }

    public async Task<bool> ClientHasTripsAsync(int idClient)
    {
        return await _context.ClientTrips.AnyAsync(ct => ct.IdClient == idClient);
    }

    public async Task DeleteClientAsync(int idClient)
    {
        var client = await _context.Clients.FindAsync(idClient);
        if (client == null)
        {
            throw new ArgumentException($"Client with ID {idClient} not found.");
        }

        _context.Clients.Remove(client);
        await _context.SaveChangesAsync();
    }
}


    
