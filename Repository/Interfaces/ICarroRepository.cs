using Model;

namespace Repository.Interfaces;

public interface ICarroRepository
{
    public void Criar(Carro carro);

    public void Editar(Carro carro);

    public void Delete(Guid id);

    public IList<Carro> ListarTodos();

    public Carro ObterPorId(Guid id);
}
