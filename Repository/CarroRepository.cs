using Model;
using Repository.Interfaces;

namespace Repository;

public class CarroRepository : ICarroRepository
{

    private Context _context;
    public CarroRepository(Context context)
    {
        _context = context;
    }

    public void Criar(Carro carro)
    {
        throw new NotImplementedException();
    }

    public void Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public void Editar(Carro carro)
    {
        throw new NotImplementedException();
    }

    public IList<Carro> ListarTodos()
    {
        return _context.Carros.ToList();
    }

    public Carro ObterPorId(Guid id)
    {
        return _context.Carros.Where(c => c.Id == id).First();
    }
}
