using Microsoft.AspNetCore.Mvc;
using Model;
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

            return Ok(carros);
        }
        catch (Exception ex)
        {
            return BadRequest(new { mensagem = "Ocorreu um erro ao processar sua requisão", strackTrace = ex.ToString() });
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> Listar(Guid id)
    {
        var carro = await _carroService.ObterPorId(id);
        return Ok(carro);
    }

    [HttpPost]
    public async Task<ActionResult> Criar(Carro carro)
    {
        try
        {
            var id = await _carroService.Criar(carro);
            return Ok(id);
        }
        catch (Exception ex)
        {
            return BadRequest(new { mensagem = "Ocorreu um erro ao processar sua requisão", strackTrace = ex.ToString() });
        }
    }
    
    [HttpPut]
    public async Task<ActionResult> Editar(Carro carroAEditar)
    {
        try
        {
            await _carroService.Editar(carroAEditar);
            return Ok(new { Messagem = $"Carro com Id {carroAEditar.Id} foi editado com sucesso" });
        }
        catch( Exception ex)
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
        catch(Exception ex)
        {
            return BadRequest(new { mensagem = "Ocorreu um erro ao processar sua requisão", strackTrace = ex.ToString() });
        }
    }
}
