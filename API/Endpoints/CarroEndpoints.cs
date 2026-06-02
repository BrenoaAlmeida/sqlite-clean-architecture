using API.DTO;
using Application.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API.Endpoints;

internal static class CarroEndpoints
{
    public static IEndpointRouteBuilder MapCarroEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var root = endpoints.MapGroup("api/carro").WithTags("Carro");

        root.MapGet("", async (
            ICarroService carroService,
            CancellationToken cancellationToken
            ) =>
        {
            try
            {
                var results = await carroService.ListarTodos(cancellationToken);

                if (results.Count() == 0)
                    return Results.Ok("Nenhum registro foi encontrado");

                var carrosDto = results.Select(c => new CarroDTO(c)).ToList();
                return Results.Ok(carrosDto);
            }
            catch (Exception ex)
            {
                return Results.InternalServerError(new { Message = "Ocorreu  um erro ao processar sua requisição", stackTrace = ex.ToString() });
            }
        })
        .WithDescription("Endpoint que retorna uma lista de Carros")
        .Produces<IList<CarroDTO>>(StatusCodes.Status200OK)
        .Produces<Exception>(StatusCodes.Status500InternalServerError);

        root.MapGet("{id}", async (
            ICarroService carroService,
            Guid id,
            CancellationToken cancellationToken) =>
        {
            try
            {
                var carro = await carroService.ObterPorId(id, cancellationToken);
                var carroDTO = new CarroDTO(carro);
                return Results.Ok(carroDTO);
            }
            catch (InvalidOperationException ex)
            {
                return Results.BadRequest(new { mensagem = ex.Message });
            }
            catch (Exception ex)
            {
                return Results.InternalServerError(new { Message = "Ocorreu  um erro ao processar sua requisição", stackTrace = ex.ToString() });
            }
        }).
        WithDescription("Retorna um Carro especifico baseado no Id")
        .Produces<CarroDTO>(StatusCodes.Status200OK)
        .Produces<BadRequest>(StatusCodes.Status400BadRequest)
        .Produces<Exception>(StatusCodes.Status500InternalServerError);

        root.MapPost("", async (
            ICarroService carroService,
            [FromBody] CriarCarroDTO criarCarroDTO,
            CancellationToken cancellationToken
            ) =>
        {
            try
            {
                var carro = CriarCarroDTO.DtoToModel(criarCarroDTO);
                var id = await carroService.Criar(carro, cancellationToken);
                return Results.Created("api/carro", new { id });
            }
            catch (Exception ex)
            {
                return Results.InternalServerError(new { mensagem = "Ocorreu um erro ao processar sua requisão", strackTrace = ex.ToString() });
            }
        })
        .WithDescription("Criação de Carros")
        .Produces<Guid>(StatusCodes.Status201Created)
        .Produces<Exception>(StatusCodes.Status500InternalServerError);

        root.MapPut("", async (
            ICarroService carroService,
            [FromBody] CarroDTO carroAEditar,
            CancellationToken cancellationToken
            ) =>
        {
            try
            {
                await carroService.Editar(CarroDTO.DtoToModel(carroAEditar), cancellationToken);
                return Results.Ok(new { Messagem = $"Carro com Id {carroAEditar.Id} foi editado com sucesso" });
            }
            catch (Exception ex)
            {
                return Results.InternalServerError(new { mensagem = "Ocorreu um erro ao processar sua requisão", strackTrace = ex.ToString() });
            }
        })
            .WithDescription("Edição de carro")
            .Produces<CarroDTO>(StatusCodes.Status200OK)
            .Produces<Exception>(StatusCodes.Status500InternalServerError);

        root.MapDelete("", async (
            ICarroService carroService,
            Guid id,
            CancellationToken cancellationToken
            ) =>
        {
            try
            {
                await carroService.Excluir(id, cancellationToken);
                return Results.Ok(new { Messagem = $"Carro com Id {id} foi excluido com sucesso" });
            }
            catch (Exception ex)
            {
                return Results.InternalServerError(new { mensagem = "Ocorreu um erro ao processar sua requisão", strackTrace = ex.ToString() });
            }
        })
            .WithDescription("Exclusão de Carro por Id")
            .Produces<string>(StatusCodes.Status204NoContent)
            .Produces<Exception>(StatusCodes.Status500InternalServerError);

        return endpoints;
    }
}