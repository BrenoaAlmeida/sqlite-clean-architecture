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

    public async Task<Guid> Criar(Carro carro)
    {
        await _unitOfWork.GetRepository<Carro>().Add(carro);
        await _unitOfWork.SalvarAsync();

        return carro.Id;
    }

    public async Task Excluir(Guid id)
    {
        var carro = await ObterPorId(id);


        _unitOfWork.GetRepository<Carro>().Delete(carro);
        await _unitOfWork.SalvarAsync();
    }

    public async Task Editar(Carro carro)
    {        
        var carroDoBanco = await ObterPorId(carro.Id);


        carroDoBanco.Nome = carro.Nome;
        carroDoBanco.Marca = carro.Marca;
        carro.Preco = carro.Preco;
        await _unitOfWork.SalvarAsync();        
    }

    public async Task<IList<Carro>> ListarTodos()
    {
        return await _unitOfWork.GetRepository<Carro>().GetAll();
    }

    public async Task<Carro> ObterPorId(Guid id)
    {
        if (id == Guid.Empty || id.Equals(string.Empty))
            throw new InvalidOperationException("Id não pode ser nulo");

        var carro = await _unitOfWork.GetRepository<Carro>().FindByIdAsync(id);

        if (carro == null)
            throw new InvalidOperationException("Não existe registro no banco para o Id Informado");

        return carro;
    }
}
