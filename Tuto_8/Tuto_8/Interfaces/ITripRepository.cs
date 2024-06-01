using Tuto_8.DTOs;
using Tuto_8.Models;

namespace Tuto_8.Interfaces;

public interface ITripRepository
{
    Task<PaginatedList<GetTripDtos>> GetTripsAsync(int page, int pageSize);

}