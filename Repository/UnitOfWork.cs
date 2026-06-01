using Domain.Contexto;
using Infrastructure;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;

namespace Repository;

public class UnitOfWork : IUnitOfWork
{    
    private readonly DbContext _context;
    private readonly Dictionary<Type, object> _repositorios = new();

    public UnitOfWork(DbContext context)
    {
        _context = context;
    }
    
    public async Task SalvarAsync() => await _context.SaveChangesAsync();

    public IGenericRepository<T> GetRepository<T>() where T : class
    {
        var tipoRepositorio = typeof(T);

        if(!_repositorios.TryGetValue(tipoRepositorio, out var repo))
        {
            repo = new GenericRepository<T>(_context);
            _repositorios[tipoRepositorio] = repo;
        }

        return (IGenericRepository<T>)repo;
    }
}
