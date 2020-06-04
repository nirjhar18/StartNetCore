using Microsoft.EntityFrameworkCore;
using Weather.Api.Repositories.WeatherRepository.DtoModels;

namespace Weather.Api.Repositories.WeatherRepository.Context
{
    public class WeatherContext : DbContext
    {
        public WeatherContext(DbContextOptions<WeatherContext> options) : base(options)
        {

        }

        public DbSet<WeatherDtoModel> Weather { get; set; }
    }
}
