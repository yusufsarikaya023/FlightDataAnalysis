namespace Domain.Abstract;

/// <summary>
/// Interface for file reader service
/// </summary>
public interface ITransaction: IDisposable
{
    /// <summary>
    /// Commit the transaction
    /// </summary>
    Task CommitAsync(CancellationToken cancellationToken);
    
    /// <summary>
    /// Rollback the transaction
    /// </summary>
    Task RollbackAsync(CancellationToken cancellationToken);
}