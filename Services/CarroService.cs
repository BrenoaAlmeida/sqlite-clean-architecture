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
        await _unitOfWork.CarroRepository.Criar(carro);
        await _unitOfWork.Salvar();

        return carro.Id;
    }

    public async Task Excluir(Guid id)
    {
        var carro = await ObterPorId(id);


        _unitOfWork.CarroRepository.Excluir(carro);
        await _unitOfWork.Salvar();
    }

    public async Task Editar(Carro carro)
    {
        await ObterPorId(carro.Id);
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
            throw new InvalidOperationException("Id não pode ser nulo");

        var carro = await _unitOfWork.CarroRepository.ObterPorId(id);

        if (carro == null)
            throw new InvalidOperationException("Não existe registro no banco para o Id Informado");

        return carro;
    }
}
