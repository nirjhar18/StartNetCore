using AutoMapper;
using System;
using System.Threading.Tasks;
using Weather.Api.Repositories;
using Weather.Api.Repositories.WeatherRepository.DtoModels;
using Weather.Api.Services.Weather.DomainModels;

namespace WeatherForcecast.Api.Services.Weather
{
    public class WeatherService : IWeatherService
    {
        private readonly IWeatherRepository _weatherRepository;
        private readonly IMapper _mapper;
        public WeatherService(IWeatherRepository weatherRepository,
            IMapper mapper)
        {
            _weatherRepository = weatherRepository;
            _mapper = mapper;

        }
        public async Task<bool> AddWeatherByCity(WeatherCityDomainModel request)
        {
            var response = await _weatherRepository.AddWeatherForCity(_mapper.Map<WeatherDtoModel>(request));
            return Convert.ToBoolean(response);
        }

        public async Task<string> GetWeatherByCity(string city)
        {
            var cityWeather = await Task.FromResult("cold");
            return cityWeather;
        }
    }
}
