using System.ComponentModel.DataAnnotations;

namespace Model;
public class Carro()
{

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

    public bool Validar()
    {

        if (this.Preco == 0)
            return false;
        
        if(this.Id == Guid.Empty || this.Id == default)
            return false;

        return true;

    }
}
