using Infrastructure.Interfaces;

namespace Repository.Interfaces;

public interface IUnitOfWork
{
    IGenericRepository<T> GetRepository<T>() where T : class;
    Task SalvarAsync();
}
