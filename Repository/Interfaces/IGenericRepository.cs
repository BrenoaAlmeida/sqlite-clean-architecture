namespace Infrastructure.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task AddAsync(T entity, CancellationToken cancellationToken);

    void Update(T entity);

    Task<T?> FindByIdAsync(Guid id, CancellationToken cancellationToken, bool asNoTracking = true);

    public void Delete(T entity);

    public IQueryable<T> GetAll(CancellationToken cancellationToken, bool asNoTracking = true);
}
