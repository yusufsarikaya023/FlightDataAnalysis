using Domain.Abstract;

namespace Domain.Aggregation.AirCrafts;

public interface IAirCraftRepository: IRepository
{
    Task Add(AirCraft airCraft);
    Task<AirCraft?> GetByRegistrationNumber(string registrationNumber);
}