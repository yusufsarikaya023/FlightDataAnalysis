using Domain.Abstract;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.Repositories;

public class Transaction(Context context) : ITransaction
{
    private readonly IDbContextTransaction _scope = context.Database.BeginTransaction();

    public void Dispose() => _scope.Dispose();

    public async Task CommitAsync(CancellationToken cancellationToken)
    {
        await _scope.CommitAsync(cancellationToken);
    }

    public async Task RollbackAsync(CancellationToken cancellationToken)
    {
        await _scope.RollbackAsync(cancellationToken);
    }
}