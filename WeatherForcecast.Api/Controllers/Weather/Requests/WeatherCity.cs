using System.ComponentModel.DataAnnotations;

namespace Weather.Api.Controllers.Weather.Requests
{
    public class WeatherCity
    {
        public string City { get; set; }

        [Required]
        [Range(-100, 60)]
        public int Temperature { get; set; }

        public string Weather { get; set; }

        //public int TemperatureInF
        //{
        //    get { return TemperatureInF; }


        //    set { _ = Temperature * 2; }

        //}
    }
}
