namespace Infrastructure.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task Add(T entity);

    void Update(T entity);

    Task<T?> FindByIdAsync(Guid id);

    public void Delete(T entity);

    public Task<IList<T>> GetAll();
}
