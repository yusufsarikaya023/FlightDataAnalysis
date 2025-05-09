namespace Domain.Abstract;

public interface IUnitOfWork
{
    Task SaveAsync();
}