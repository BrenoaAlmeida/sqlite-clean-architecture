using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private DbContext _context;

    public GenericRepository(DbContext context)
    {
        _context = context;
    }
    
    public async Task AddAsync(T entity, CancellationToken cancellationToken) => await _context.Set<T>().AddAsync(entity, cancellationToken);

    public void Update(T entity) => _context.Set<T>().Update(entity);

    public async Task<T?> FindByIdAsync(Guid id, CancellationToken cancellationToken, bool asNoTracking = true)
    {
        IQueryable<T> query = _context.Set<T>();

        if (asNoTracking)
            query = query.AsNoTracking();        
        return await query.FirstOrDefaultAsync(e => EF.Property<Guid>(e, "Id") == id, cancellationToken);
    }

    public void Delete(T entity) => _context.Set<T>().Remove(entity);

    public IQueryable<T> GetAll(CancellationToken cancellationToken, bool asNoTracking = true)
    {
        IQueryable<T> query = _context.Set<T>();

        if (asNoTracking)
            query = query.AsNoTracking();

        return query;
    }

}
