using Model;
using Repository.Interfaces;

namespace Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly ICarroRepository _carroRepository;
    private readonly Context _context;

    public UnitOfWork(Context context, ICarroRepository carroRepository)
    {
        _carroRepository = carroRepository;
        _context = context;
    }

    public async Task Salvar() 
    {
        await _context.SaveChangesAsync();
    }

    public ICarroRepository CarroRepository => _carroRepository;
}
