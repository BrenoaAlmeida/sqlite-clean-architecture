namespace Infrastructure.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task Add(T entity, CancellationToken cancellationToken);

    void Update(T entity);

    Task<T?> FindByIdAsync(Guid id, CancellationToken cancellationToken, bool asNoTracking = true);

    public void Delete(T entity);

    public Task<IList<T>> GetAll(CancellationToken cancellationToken, bool asNoTracking = true);
}
