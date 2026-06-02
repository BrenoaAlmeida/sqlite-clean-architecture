using API.Endpoints;

namespace API.Extentions;
public static class MapEndpointsExtention
{
    public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder endpoint)
    {
        return endpoint
            .MapWeatherForecastEndpoints()
            .MapCarroEndpoints();
    }
}
