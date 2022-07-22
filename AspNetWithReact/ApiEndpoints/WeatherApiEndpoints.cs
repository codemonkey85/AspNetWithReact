namespace AspNetWithReact.ApiEndpoints;

public static class WeatherApiEndpoints
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public static IEndpointRouteBuilder MapWeatherApiEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("WeatherForecast", Get);
        return app;
    }

    private static IResult Get() => Results.Ok(Enumerable.Range(1, 5).Select(index => new WeatherForecast
    (
        DateTime.Now.AddDays(index),
        Random.Shared.Next(-20, 55),
        Summaries[Random.Shared.Next(Summaries.Length)]
    )).ToArray());
}

public record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}