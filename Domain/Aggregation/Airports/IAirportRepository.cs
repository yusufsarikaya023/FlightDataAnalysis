using Domain.Abstract;

namespace Domain.Aggregation.Airports;

public interface IAirportRepository: IRepository
{
    Task Add(Airport airport);
    Task<Airport?> GetByCode(string code);
}