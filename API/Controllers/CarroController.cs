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
    public ActionResult Listar()
    {
        try
        {
            var carros = _carroService.ListarTodos();
            return Ok(carros);
        }
        catch (Exception ex)
        {
            return BadRequest(new { mensagem = "Ocorreu um erro ao processar sua requisão", strackTrace = ex.ToString() });
        }
    }

    [HttpGet("{id}")]
    public ActionResult Listar(int id)
    {
        return View();
    }

    [HttpPost]
    public ActionResult Criar(Carro carro)
    {
        try
        {
            var id = _carroService.Criar(carro);
            return Ok(id);
        }
        catch (Exception ex)
        {
            {
                return BadRequest(new { mensagem = "Ocorreu um erro ao processar sua requisão", strackTrace = ex.ToString() });

            }
        }
    }

        // POST: CarroController/Edit/5
        [HttpPut]
        public ActionResult Editar(int id)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: CarroController/Delete/5
        [HttpDelete]
        public ActionResult Excluir(int id)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
