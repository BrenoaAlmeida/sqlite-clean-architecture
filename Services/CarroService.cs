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

    public async Task<Guid> Criar(Carro carro)
    {
        carro.Id = Guid.NewGuid();

        if (!carro.Validar())
            throw new Exception("Dados invalidos para inserção");

        await _unitOfWork.CarroRepository.Criar(carro);
        await _unitOfWork.Salvar();

        return carro.Id;
    }

    public async Task Excluir(Guid id)
    {
        var carro = await _unitOfWork.CarroRepository.ObterPorId(id);

        if (carro.Id == Guid.Empty)
            return;

        _unitOfWork.CarroRepository.Excluir(carro);
        await _unitOfWork.Salvar();
    }

    public async Task Editar(Carro carro)
    {
        await _unitOfWork.CarroRepository.Editar(carro);
        await _unitOfWork.Salvar();
    }

    public async Task<IList<Carro>> ListarTodos()
    {
        return await _unitOfWork.CarroRepository.ListarTodos();
    }

    public async Task<Carro> ObterPorId(Guid id)
    {
        if (id == Guid.Empty || id.Equals(string.Empty))
            return null;

        return await _unitOfWork.CarroRepository.ObterPorId(id); 
    }
}
