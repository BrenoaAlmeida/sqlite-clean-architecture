using Domain.Contexto;
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

    public async Task Add(T entity) => await _context.Set<T>().AddAsync(entity);

    public void Update(T entity) => _context.Set<T>().Update(entity);

    public async Task<T?> FindByIdAsync(Guid id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public void Delete(T entity) => _context.Set<T>().Remove(entity);

    public async Task<IList<T>> GetAll()
    {
        var entities = _context.Set<T>().ToList();
        return entities;
    }

}
