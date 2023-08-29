using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather_Task.Interfaces;

namespace Weather_Task.Services
{
	public class WeatherService
	{
		private readonly IWeatherApi _weatherApi;

		public WeatherService(IWeatherApi weatherApi)
		{
			_weatherApi = weatherApi;
		}

		public async Task ShowWeather()
		{
			double weatherFromWeatherApi = await _weatherApi.GetTodayWeather();
			double weatherFromMeteostat = await _weatherApi.GetTodayWeather();

			Log.Information("Current temperature (weatherapi) - {Temperature} degrees centigrade", weatherFromWeatherApi);
			Log.Information("Current temperature (meteostat) - {Temperature} degrees centigrade", weatherFromMeteostat);
		}
	}
}
