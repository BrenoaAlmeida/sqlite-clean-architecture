using System.ComponentModel.DataAnnotations;

namespace Model;

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

    [Key]
    public Guid Id { get; set; }

    [MaxLength(60)]
    [Required]
    public string Nome { get; set; } = string.Empty;

    [Required]
    public double Preco { get; set; }

    [MinLength(5)]
    [MaxLength(60)]
    public string? Marca { get; set; }

    public Carro Atualizar(string nome, string marca, double preco)
    {
        this.Nome = nome;
        this.Marca = marca;
        this.Preco = preco;

        return this;
    }
}