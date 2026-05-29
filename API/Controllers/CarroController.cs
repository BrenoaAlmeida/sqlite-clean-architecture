using API.DTO;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class CarroController : Controller
{
    private readonly ICarroService _carroService;
    public CarroController(ICarroService carroService)
    {
        _carroService = carroService;
    }

    [HttpGet]
    public async Task<ActionResult> Listar()
    {
        try
        {
            var carros = await _carroService.ListarTodos();

            if (carros.Count == 0)
                return Ok("Nenhum registro foi encontrado");

            var carrosDTO = new List<CarroDTO>();
            carrosDTO.AddRange(carros.Select(c => new CarroDTO(c)));

            return Ok(carrosDTO);
        }
        catch (Exception ex)
        {
            return BadRequest(new { mensagem = "Ocorreu um erro ao processar sua requisão", strackTrace = ex.ToString() });
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> ObterPorId(Guid id)
    {
        try
        {
            var carro = await _carroService.ObterPorId(id);
            var carroDTO = new CarroDTO(carro);
            return Ok(carroDTO);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { mensagem = ex.Message });
        }
        catch (Exception ex)
        {
            return BadRequest(new { mensagem = "Houve um erro ao processar sua requisição", stackTrace = ex.ToString() });
        }
    }

    [HttpPost]
    public async Task<ActionResult> Criar(CriarCarroDTO carroDTO)
    {
        try
        {
            var carro = CriarCarroDTO.DtoToModel(carroDTO);
            var id = await _carroService.Criar(carro);
            return Created(nameof(ObterPorId), new { id });
        }
        catch (Exception ex)
        {
            return BadRequest(new { mensagem = "Ocorreu um erro ao processar sua requisão", strackTrace = ex.ToString() });
        }
    }

    [HttpPut]
    public async Task<ActionResult> Editar(CarroDTO carroAEditar)
    {
        try
        {
            await _carroService.Editar(CarroDTO.DtoToModel(carroAEditar));
            return Ok(new { Messagem = $"Carro com Id {carroAEditar.Id} foi editado com sucesso" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { mensagem = "Ocorreu um erro ao processar sua requisão", strackTrace = ex.ToString() });
        }
    }

    [HttpDelete("{id}")]
    public ActionResult Excluir(Guid id)
    {
        try
        {
            _carroService.Excluir(id);
            return Ok(new { Messagem = $"Carro com Id {id} foi excluido com sucesso" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { mensagem = "Ocorreu um erro ao processar sua requisão", strackTrace = ex.ToString() });
        }
    }
}
