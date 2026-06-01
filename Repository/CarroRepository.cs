using Domain.Contexto;
using Microsoft.EntityFrameworkCore;
using Domain;
using Repository.Interfaces;

namespace Repository;

public class CarroRepository : ICarroRepository
{

    private SqliteContext _context;
    public CarroRepository(SqliteContext context)
    {
        _context = context;
    }

    public async Task Criar(Carro carro)
    {
        await _context.Carros.AddAsync(carro);
    }

    public void Excluir(Carro carro)
    {
        _context.Carros.Remove(carro);
    }

    public async Task Editar(Carro carro)
    {
        var carroDoBanco = await _context.Carros.FindAsync(carro.Id);

        if (carroDoBanco == null)
            throw new InvalidOperationException("Não existe Carro para o Id informado");


        carroDoBanco.Nome = carro.Nome;
        carroDoBanco.Marca = carro.Marca;
        carro.Preco = carro.Preco;
    }

    public async Task<IList<Carro>> ListarTodos()
    {
        return await _context.Carros.ToListAsync();
    }

    public async Task<Carro?> ObterPorId(Guid id) => await _context.Carros.FirstOrDefaultAsync(c => c.Id == id);
}
