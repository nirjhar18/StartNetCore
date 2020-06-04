using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Weather.Api.Repositories.WeatherRepository.Context;
using Weather.Api.Repositories.WeatherRepository.DtoModels;

namespace Weather.Api.Repositories.WeatherRepository
{
    public class WeatherRepository : IWeatherRepository
    {
        private readonly WeatherContext _context;
        public WeatherRepository(WeatherContext context)
        {
            _context = context;
        }

        public async Task<bool> AddWeatherForCity(WeatherDtoModel weather)
        {
            _context.Weather.Add(weather);
            var response = await _context.SaveChangesAsync();

            return Convert.ToBoolean(response);
        }

        public Task<WeatherDtoModel> GetWeatherByCity()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<WeatherDtoModel>> GetWeatherForAllCities()
        {

            throw new NotImplementedException();
        }
    }
}
