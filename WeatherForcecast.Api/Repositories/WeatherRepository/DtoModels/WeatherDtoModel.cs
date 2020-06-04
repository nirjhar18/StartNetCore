namespace Weather.Api.Repositories.WeatherRepository.DtoModels
{
    public class WeatherDtoModel
    {
        public long Id { get; set; }
        public string City { get; set; }
        public string Weather { get; set; }
        public int Temperature { get; set; }
    }
}
