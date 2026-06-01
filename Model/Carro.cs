namespace Domain;

public class Carro
{
    protected Carro() { }

    public Carro(Guid id, string nome, string marca, double preco)
    {
        if (string.IsNullOrEmpty(nome))
            throw new InvalidOperationException("Nome deve ter um valor");

        if (string.IsNullOrEmpty(marca))
            throw new InvalidOperationException("Marca deve ter um valor");

        if (preco <= 0)
            throw new InvalidOperationException("Preço não pode ser zero");

        Id = id == Guid.Empty ? Guid.CreateVersion7() : id;
        Nome = nome;
        Marca = marca;
        Preco = preco;
    }

    public Guid Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public double Preco { get; set; }

    public string Marca { get; set; }    
}