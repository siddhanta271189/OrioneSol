using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Formatting.Json;
using Weather_Task.Implementations;
using Weather_Task.Interfaces;
using Weather_Task.Services;

class Program
{
	static async Task Main(string[] args)
	{ 
        // Configure Serilog for logging
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File(new JsonFormatter(), "log.json")
            .CreateLogger();

        // Dependency Injection
        var serviceProvider = new ServiceCollection()
            .AddScoped<IWeatherApi, WeatherApiCom>() // Change to MeteoStatApi for the other implementation
           // .AddHttpClient() // Register HttpClient
            .BuildServiceProvider();

        // Retrieve weather API instance from DI
        var weatherApi = serviceProvider.GetService<IWeatherApi>();

        try
        {
            // Fetch and log weather data
            Task<double> temperature = await WeatherApiCom.GetTodayWeather();
            Log.Information("Current temperature - {Temperature} degrees centigrade", temperature);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "An error occurred while fetching weather data.");
        }
        finally
        {
            // Close and flush the logger
            Log.CloseAndFlush();
        }

    }
}
