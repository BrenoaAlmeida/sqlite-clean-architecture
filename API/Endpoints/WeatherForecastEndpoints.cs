using Domain;
namespace API.Endpoints;

internal static class WeatherForecastEndpoints
{
    private static readonly string[] Summaries = ["Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"];

    internal static IEndpointRouteBuilder MapWeatherForecastEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var root = endpoints.MapGroup("api/weather-forecast").WithTags("WeatherForecast");

        root.MapGet("", async () =>
        {
            var result = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToArray();
            return result;
        })
            .WithDescription("Api de teste Hello Word")
            .Produces<IEnumerable<WeatherForecast>>(StatusCodes.Status200OK);
        return endpoints;
    }
}