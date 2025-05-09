using Domain.Abstract;
using Domain.Aggregation.AirCrafts;
using Infrastructure.Repositories;

namespace Infrastructure;

public class UnitOfWork(Context context): IUnitOfWork
{
    public ITransaction BeginTransaction()
    {
        return new Transaction(context);
    }
    
    public Task SaveAsync()
    {
        return context.SaveChangesAsync();
    }
    
    private IAirCraftRepository? _airCraftRepository;
    public IAirCraftRepository AirCraftRepository()
    {
        return _airCraftRepository ??= new AirCraftRepository(context);
    }
}