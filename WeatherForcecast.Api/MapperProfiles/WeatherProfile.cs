using AutoMapper;
using Weather.Api.Controllers.Weather.Requests;
using Weather.Api.Repositories.WeatherRepository.DtoModels;
using Weather.Api.Services.Weather.DomainModels;

namespace Weather.Api.MapperProfiles
{
    public class WeatherProfile : Profile
    {

        public WeatherProfile()
        {
            CreateMap<WeatherCity, WeatherCityDomainModel>().ReverseMap();

            CreateMap<WeatherCityDomainModel, WeatherDtoModel>().ReverseMap();
        }
    }
}
