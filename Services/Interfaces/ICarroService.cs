using Domain;

namespace Application.Interfaces;

public interface ICarroService
{
    Task<Guid> Criar(Carro carro);

    Task Editar(Carro carro);

    Task Excluir(Guid id);

    Task<IList<Carro>> ListarTodos();

    Task<Carro> ObterPorId(Guid id);
}
