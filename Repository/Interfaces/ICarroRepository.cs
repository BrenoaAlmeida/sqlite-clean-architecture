using Domain;

namespace Repository.Interfaces;

public interface ICarroRepository
{
    Task Criar(Carro carro);

    Task Editar(Carro carro);

    void Excluir(Carro carro);

    Task<IList<Carro>> ListarTodos();

    Task<Carro?> ObterPorId(Guid id);
}
