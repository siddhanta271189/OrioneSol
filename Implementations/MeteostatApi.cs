using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather_Task.Interfaces;
using System.Net.Http.Headers;
using RestSharp;

namespace Weather_Task.Implementations
{
    public class MeteostatApi : IWeatherApi
    {
        public double body;

        public async Task<double> GetTodayWeather()
        {

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://meteostat.p.rapidapi.com/stations/hourly?station=10637&start=2020-01-01&end=2020-01-01&tz=Europe%2FBerlin"),
                Headers =
    {
        { "X-RapidAPI-Key", "cdcb901245msh26859ae5038d423p1a9a97jsna7b1c91d9028" },
        { "X-RapidAPI-Host", "meteostat.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                string v = await response.Content.ReadAsStringAsync();
                body = Double.Parse(v); 
            }
            return body;
        }
    }
}
