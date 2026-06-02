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
    /*MELHORIAS
     
     ADICIONAR SUFIXO ASYNC EM METODOS ASYNC 
    NO GETALL MUDAR PARA QUERYABLE E DEIXAR O USUARIO FAZER O QUE QUISER COM A QUERY, POR QUE O BANCO PODE TER 1 MILHÃO DE REGISTROS
     */
    public async Task Add(T entity, CancellationToken cancellationToken) => await _context.Set<T>().AddAsync(entity, cancellationToken);

    public void Update(T entity) => _context.Set<T>().Update(entity);

    public async Task<T?> FindByIdAsync(Guid id, CancellationToken cancellationToken, bool asNoTracking = true)
    {
        IQueryable<T> query = _context.Set<T>();

        if (asNoTracking)
            query = query.AsNoTracking();        
        return await query.FirstOrDefaultAsync(e => EF.Property<Guid>(e, "Id") == id, cancellationToken);
    }

    public void Delete(T entity) => _context.Set<T>().Remove(entity);

    public async Task<IList<T>> GetAll(CancellationToken cancellationToken, bool asNoTracking = true)
    {
        IQueryable<T> query = _context.Set<T>();

        if (asNoTracking)
            query = query.AsNoTracking();

        return await query.ToListAsync(cancellationToken);
    }

}
