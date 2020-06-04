using System.Threading.Tasks;
using Weather.Api.Services.Weather.DomainModels;

namespace WeatherForcecast.Api.Services.Weather
{
    public interface IWeatherService
    {
        Task<string> GetWeatherByCity(string city);

        Task<bool> AddWeatherByCity(WeatherCityDomainModel request);
    }
}
