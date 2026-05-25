using Model;

namespace Services.Interfaces;

public interface ICarroService
{
    public Guid Criar(Carro carro);

    public void Editar(Carro carro);

    public void Delete(Guid id);

    public IList<Carro> ListarTodos();

    public Carro ObterPorId(Guid id);
}
