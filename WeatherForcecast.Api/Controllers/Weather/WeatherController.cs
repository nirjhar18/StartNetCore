using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Weather.Api.Controllers.Weather.Requests;
using Weather.Api.Controllers.Weather.Responses;
using Weather.Api.Services.Weather.DomainModels;
using WeatherForcecast.Api.Services.Weather;

namespace WeatherForcecast.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : Controller
    {
        private readonly ILogger<WeatherController> _logger;
        private readonly IMapper _mapper;
        private readonly IWeatherService _weatherService;
        public WeatherController(ILogger<WeatherController> logger,
            IWeatherService weatherService,
            IMapper mapper)
        {
            _logger = logger;
            _weatherService = weatherService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        public async Task<string> GetWeather()
        {
            _logger.LogInformation("Testing 1");
            return await Task.FromResult("Test");
        }

        [HttpGet]
        [Route("{city}")]
        public async Task<string> GetWeatherByCity(string city)
        {
            var weatherbyCity = await _weatherService.GetWeatherByCity(city);

            return weatherbyCity;
        }

        [HttpPost]
        [Route("AddWeather")]
        public async Task<ActionResult<WeatherCityResponse>> AddWeatherForCity(WeatherCity request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                _logger.LogInformation("Error");
                throw new Exception("error");
            }
            try
            {
                var domainRequest = _mapper.Map<WeatherCityDomainModel>(request);
                var result = await _weatherService.AddWeatherByCity(domainRequest);
                return CreatedAtAction(nameof(AddWeatherForCity), result);
            }
            catch
            {
                _logger.LogInformation("Error");
                return BadRequest();
            }


        }
    }
}
