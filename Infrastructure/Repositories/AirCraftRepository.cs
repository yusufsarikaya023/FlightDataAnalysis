using Domain.Aggregation.AirCrafts;

namespace Infrastructure.Repositories;

public class AirCraftRepository(Context context) : Repository, IAirCraftRepository
{
    public async Task Add(AirCraft airCraft)
    {
        await context.AirCrafts.AddAsync(airCraft);
    }

    public Task<AirCraft?> GetByRegistrationNumber(string registrationNumber)
    {
        return context.AirCrafts.FirstOrDefaultAsync(x => x.RegistrationNumber == registrationNumber);
    }
}