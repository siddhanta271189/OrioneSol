using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather_Task.Interfaces;
using System.Net.Http.Headers;
using RestSharp;
using System.Net;
using Newtonsoft.Json;
using System.Net.Http;

namespace Weather_Task.Implementations
{
    public class WeatherApiCom : IWeatherApi
    {

        private readonly HttpClient _httpClient;
        public double temp;

        public WeatherApiCom(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<double> GetTodayWeather()
        {
            // Call WeatherAPI.com API and get the temperature

            string apiUrl = "http://api.weatherapi.com/v1/current.json?key=51994041956a42f8a2f85410232908&q=London&aqi=no";

            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
            //response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                var tempresponse = response.Content.ReadAsStringAsync().Result;
                temp = JsonConvert.DeserializeObject<double>(tempresponse);
            }

            return temp;


            //        using(var client=new HttpClient()) 
            //{
            //	client.BaseAddress = new Uri(BaseURL);
            //	client.DefaultRequestHeaders.Accept.Clear();
            //	client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //	HttpResponseMessage res = await client.GetAsync();
            //	if(res.IsSuccessStatusCode)
            //	{
            //		var tempResponse=res.Content.ReadAsStringAsync().Result;
            //	}
            //}
        }
    }
}
