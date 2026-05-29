using Model;
using System.ComponentModel.DataAnnotations;

namespace API.DTO;

public class CriarCarroDTO
{
    public CriarCarroDTO()
    {
        
    }

    public CriarCarroDTO(Carro carro)
    {
        Nome = carro.Nome;
        Preco = carro.Preco;
        Marca = carro.Marca;
    }

    [MaxLength(60)]
    [Required(ErrorMessage = "É necessario informar o Nome do Carro")]
    public string Nome { get; set; }

    [Range(0.1, 999999, ErrorMessage = "É necessario informar um valor maior que zero")]
    [Required(ErrorMessage = "É necessario informar o Preco do Carro")]
    public double Preco { get; set; }

    [MinLength(5, ErrorMessage = "E necessario informar uma marca com mais de 5 caracteres")]
    [MaxLength(60, ErrorMessage = "E necessario informar uma marca com menos de 60 caracteres")]
    [Required(ErrorMessage = "É necessario informar a Marca do Carro")]
    public string Marca { get; set; }

    public static Carro DtoToModel(CriarCarroDTO carroDTO)
    {
        var carro = new Carro(Guid.Empty, carroDTO.Nome, carroDTO.Marca, carroDTO.Preco);
        return carro;
    }
}
