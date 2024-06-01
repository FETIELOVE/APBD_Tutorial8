
using Tuto_8.Models;

namespace Tuto_8.Interfaces;

public interface IAssignClientToTripRepository
{
    Task<bool> ClientExistsAsync(string pesel);
    Task<bool> ClientAlreadyRegisteredForTripAsync(string pesel, int tripId);
    Task<bool> TripExistsAndFutureAsync(int tripId);
    Task AssignClientToTripAsync(ClientTrip clientTrip);
}