namespace Repository.Interfaces;

public interface IUnitOfWork
{
    ICarroRepository CarroRepository { get; }
}
