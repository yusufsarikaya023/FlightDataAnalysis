using Domain.Abstract;

namespace Domain.Aggregation.AirCrafts;

public interface IAirCraftRepository: IRepository
{
    void Add(AirCraft airCraft);
}