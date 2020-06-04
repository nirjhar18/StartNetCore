namespace Weather.Api.Controllers.Weather.Responses
{
    public class WeatherCityResponse
    {
        public int WeatherId { get; set; }
        public string City { get; set; }

        public decimal TemperatureInCelcius { get; set; }

        public decimal TemperatureInF { get; set; }

        public string Weather { get; set; }
    }
}
