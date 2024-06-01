namespace Tuto_8.Interfaces;

public interface IClientRepository
{
    Task<bool> ClientHasTripsAsync(int idClient);
    Task DeleteClientAsync(int idClient);
}