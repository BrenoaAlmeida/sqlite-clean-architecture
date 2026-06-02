using API.DTO;
using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;

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
    public async Task<ActionResult> Listar(CancellationToken cancellationToken)
    {
        try
        {
            var carros = await _carroService.ListarTodos(cancellationToken);

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
    public async Task<ActionResult> ObterPorId(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            var carro = await _carroService.ObterPorId(id, cancellationToken);
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
    public async Task<ActionResult> Criar(CriarCarroDTO carroDTO, CancellationToken cancellationToken)
    {
        try
        {
            var carro = CriarCarroDTO.DtoToModel(carroDTO);
            var id = await _carroService.Criar(carro, cancellationToken);
            return Created(nameof(ObterPorId), new { id });
        }
        catch (Exception ex)
        {
            return BadRequest(new { mensagem = "Ocorreu um erro ao processar sua requisão", strackTrace = ex.ToString() });
        }
    }

    [HttpPut]
    public async Task<ActionResult> Editar(CarroDTO carroAEditar, CancellationToken cancellationToken)
    {
        try
        {
            await _carroService.Editar(CarroDTO.DtoToModel(carroAEditar), cancellationToken);
            return Ok(new { Messagem = $"Carro com Id {carroAEditar.Id} foi editado com sucesso" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { mensagem = "Ocorreu um erro ao processar sua requisão", strackTrace = ex.ToString() });
        }
    }

    [HttpDelete("{id}")]
    public ActionResult Excluir(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            _carroService.Excluir(id, cancellationToken);
            return Ok(new { Messagem = $"Carro com Id {id} foi excluido com sucesso" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { mensagem = "Ocorreu um erro ao processar sua requisão", strackTrace = ex.ToString() });
        }
    }
}
