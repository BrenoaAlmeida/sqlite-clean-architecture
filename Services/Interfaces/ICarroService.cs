using Domain;

namespace Application.Interfaces;

public interface ICarroService
{
    Task<Guid> Criar(Carro carro, CancellationToken cancellationToken);

    Task Editar(Carro carro, CancellationToken cancellationToken);

    Task Excluir(Guid id, CancellationToken cancellationToken);

    Task<IList<Carro>> ListarTodos(CancellationToken cancellationToken);

    Task<Carro> ObterPorId(Guid id, CancellationToken cancellationToken);
}
