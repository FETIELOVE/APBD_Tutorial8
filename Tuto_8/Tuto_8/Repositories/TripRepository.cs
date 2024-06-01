using Microsoft.EntityFrameworkCore;
using Tuto_8.Interfaces;
using Tuto_8.DTOs;
using Tuto_8.Models;

namespace Tuto_8.Repositories;

public class TripRepository : ITripRepository
{
    private readonly MasterContext _context;

    public TripRepository(MasterContext context)

    {
        _context = context;
    }

    public async Task<PaginatedList<GetTripDtos>> GetTripsAsync(int page, int pageSize)
    {
        var totalCount = await _context.Trips.CountAsync();
        var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

        var trips = await _context.Trips
            .OrderByDescending(t => t.DateFrom)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Include(t => t.IdCountries)
            .Include(t => t.ClientTrips)
            .ThenInclude(ct => ct.IdClientNavigation)
            .ToListAsync();

        var tripDtos = trips.Select(t => new GetTripDtos
        {
            Name = t.Name,
            Description = t.Description,
            DateFrom = t.DateFrom,
            DateTo = t.DateTo,
            MaxPeople = t.MaxPeople,
            Countries = t.IdCountries.Select(c => new CountryDto { Name = c.Name }).ToList(),
            Clients = t.ClientTrips.Select(ct => new ClientDto
            {
                FirstName = ct.IdClientNavigation.FirstName,
                LastName = ct.IdClientNavigation.LastName
            }).ToList()
        }).ToList();

        return new PaginatedList<GetTripDtos>
        {
            PageNum = page,
            PageSize = pageSize,
            AllPages = totalPages,
            Trips = tripDtos
        };
    }

}
