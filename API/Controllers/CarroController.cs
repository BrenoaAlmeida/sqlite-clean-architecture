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
        return View();
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
            _carroService.Criar(carro);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
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
