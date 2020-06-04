using System.Collections.Generic;
using System.Threading.Tasks;
using Weather.Api.Repositories.WeatherRepository.DtoModels;

namespace Weather.Api.Repositories
{
    public interface IWeatherRepository
    {
        public Task<WeatherDtoModel> GetWeatherByCity();

        public Task<IEnumerable<WeatherDtoModel>> GetWeatherForAllCities();

        public Task<bool> AddWeatherForCity(WeatherDtoModel weather);
    }
}
