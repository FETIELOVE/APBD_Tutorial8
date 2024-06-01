
using Microsoft.EntityFrameworkCore;

using Tuto_8.Interfaces;
using Tuto_8.Models;

namespace Tuto_8.Repositories;


public class AssignClientToTripRepository : IAssignClientToTripRepository
{
    
    private readonly MasterContext _context;

    public AssignClientToTripRepository(MasterContext context)
    {
        _context = context;
    }

    public async Task<bool> ClientExistsAsync(string pesel)
    {
        return await _context.Clients.AnyAsync(c => c.Pesel == pesel);
    }

    public async Task<bool> ClientAlreadyRegisteredForTripAsync(string pesel, int tripId)
    {
        return await _context.ClientTrips.AnyAsync(ct => ct.Pesel == pesel && ct.IdTrip == tripId);
    }

    public async Task<bool> TripExistsAndFutureAsync(int tripId)
    {
        var trip = await _context.Trips.FindAsync(tripId);
        return trip != null && trip.DateFrom > DateTime.Now;
    }

    public async Task AssignClientToTripAsync(ClientTrip clientTrip)
    {
        clientTrip.RegisteredAt = DateTime.Now;
        _context.ClientTrips.Add(clientTrip);
        await _context.SaveChangesAsync();
    }
}
           