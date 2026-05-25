using Repository.Interfaces;

namespace Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly ICarroRepository _carroRepository;

    public UnitOfWork(ICarroRepository carroRepository)
    {
        _carroRepository = carroRepository;
    }

    public ICarroRepository CarroRepository => _carroRepository;
}
