namespace Weather.Api.Services.Weather.DomainModels
{
    public class WeatherCityDomainModel
    {
        public string City { get; set; }

        public int TemperatureInCelcius { get; set; }

        public string Weather { get; set; }
    }
}
