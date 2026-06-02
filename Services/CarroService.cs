using Application.Interfaces;
using Domain;
using Repository.Interfaces;

namespace Application;

public class CarroService : ICarroService
{
    private readonly IUnitOfWork _unitOfWork;

    public CarroService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Criar(Carro carro, CancellationToken cancellationToken)
    {
        await _unitOfWork.GetRepository<Carro>().Add(carro, cancellationToken);
        await _unitOfWork.SalvarAsync();

        return carro.Id;
    }

    public async Task Excluir(Guid id, CancellationToken cancellationToken)
    {
        var carro = await ObterPorId(id, cancellationToken);


        _unitOfWork.GetRepository<Carro>().Delete(carro);
        await _unitOfWork.SalvarAsync();
    }

    public async Task Editar(Carro carro, CancellationToken cancellationToken)
    {        
        var carroDoBanco = await ObterPorId(carro.Id, cancellationToken);


        carroDoBanco.Nome = carro.Nome;
        carroDoBanco.Marca = carro.Marca;
        carro.Preco = carro.Preco;
        await _unitOfWork.SalvarAsync();        
    }

    public async Task<IList<Carro>> ListarTodos(CancellationToken cancellationToken)
    {
        return await _unitOfWork.GetRepository<Carro>().GetAll(cancellationToken);
    }

    public async Task<Carro> ObterPorId(Guid id, CancellationToken cancellationToken)
    {
        if (id == Guid.Empty || id.Equals(string.Empty))
            throw new InvalidOperationException("Id não pode ser nulo");

        var carro = await _unitOfWork.GetRepository<Carro>().FindByIdAsync(id, cancellationToken);

        if (carro == null)
            throw new InvalidOperationException("Não existe registro no banco para o Id Informado");

        return carro;
    }
}
