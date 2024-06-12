namespace si730pc2u202218451.API.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}