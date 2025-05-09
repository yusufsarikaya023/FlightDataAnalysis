using Domain.Aggregation.AirCrafts;

namespace Infrastructure.Repositories;

public class AirCraftRepository(Context context) : Repository, IAirCraftRepository
{
    public void Add(AirCraft airCraft)
    {
        context.AirCrafts.Add(airCraft); 
    }
}