using Model;
using Repository.Interfaces;
using Services.Interfaces;

namespace Services;

public class CarroService : ICarroService
{
    private readonly IUnitOfWork _unitOfWork;

    public CarroService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void Criar(Carro carro)
    {
        carro.Id = Guid.NewGuid();

        if (!carro.Validar())
            throw new Exception("Dados invalidos para inserção");

        _unitOfWork.CarroRepository.Criar(carro);
    }

    public void Delete(Guid id)
    {
        _unitOfWork.CarroRepository.Delete(id);
    }

    public void Editar(Carro carro)
    {
        _unitOfWork.CarroRepository.Editar(carro);
    }

    public IList<Carro> ListarTodos()
    {
        return _unitOfWork.CarroRepository.ListarTodos();
    }

    public Carro ObterPorId(Guid id)
    {
        return _unitOfWork.CarroRepository.ObterPorId(id);
    }
}
