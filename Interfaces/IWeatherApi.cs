using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather_Task.Interfaces
{
    public interface IWeatherApi
	{
        public Task<double> GetTodayWeather();
	}
}
