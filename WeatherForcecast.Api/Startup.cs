using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Weather.Api.Controllers.Weather.Requests;
using Weather.Api.Controllers.Weather.Validators;
using Weather.Api.Repositories;
using Weather.Api.Repositories.WeatherRepository;
using Weather.Api.Repositories.WeatherRepository.Context;
using WeatherForcecast.Api.Services.Weather;

namespace WeatherForcecast.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "My API", Version = "v1" });
            });
            services.AddAutoMapper(typeof(Startup));
            services.AddDbContext<WeatherContext>(options => options.UseInMemoryDatabase("WeatherList"));

            //services.AddDbContextPool<WeatherContext>(options =>
            //options.UseSqlServer(Configuration.GetConnectionString("WeatherRepositoryConnection")));
            services.TryAddTransient<IWeatherService, WeatherService>();
            services.TryAddScoped<IWeatherRepository, WeatherRepository>();

            services.AddControllers().AddFluentValidation();
            services.AddTransient<IValidator<WeatherCity>, WeatherCityValidator>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseHttpsRedirection();

            app.UseRouting();

            // app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
