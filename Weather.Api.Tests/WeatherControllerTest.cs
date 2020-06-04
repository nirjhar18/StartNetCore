using AutoFixture;
using AutoMapper;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Weather.Api.Controllers.Weather.Requests;
using Weather.Api.Controllers.Weather.Validators;
using Weather.Api.Services.Weather.DomainModels;
using WeatherForcecast.Api.Controllers;
using WeatherForcecast.Api.Services.Weather;
using Xunit;

namespace Weather.Api.Tests
{
    public class WeatherControllerTest
    {
        private readonly Fixture _fixture = new Fixture();
        private readonly Mock<ILogger<WeatherController>> _loggerMock = new Mock<ILogger<WeatherController>>();
        private readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();
        private readonly Mock<IWeatherService> _weatherServiceMock = new Mock<IWeatherService>();
        private WeatherController _weatherController;

        public WeatherControllerTest()
        {
            _weatherController = new WeatherController(_loggerMock.Object,
                _weatherServiceMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task CheckIf_WeatherService_CalledWith_DomainModel()
        {
            var requestModel = _fixture.Create<WeatherCity>();
            var domainModel = _fixture.Create<WeatherCityDomainModel>();

            _mapperMock.Setup(x => x.Map<WeatherCityDomainModel>(It.IsAny<WeatherCity>())).Returns(domainModel);

            await _weatherController.AddWeatherForCity(requestModel);

            _mapperMock.Verify(x => x.Map<WeatherCityDomainModel>(requestModel), Times.Once());
            _weatherServiceMock.Verify(x => x.AddWeatherByCity(domainModel), Times.Once());

        }

        [Fact]
        public async Task AddWeatherForCity_Returns_Created()
        {
            var requestModel = _fixture.Create<WeatherCity>();
            var domainModel = _fixture.Create<WeatherCityDomainModel>();

            _mapperMock.Setup(x => x.Map<WeatherCityDomainModel>(It.IsAny<WeatherCity>())).Returns(domainModel);

            _weatherServiceMock.Setup(x => x.AddWeatherByCity(domainModel)).ReturnsAsync(true);

            var response = await _weatherController.AddWeatherForCity(requestModel);

            Assert.Equal((int)HttpStatusCode.Created, (response.Result as ObjectResult).StatusCode);
        }

        [Theory]
        [InlineData(500)]
        public void Temperature_NotInRange(int temperature)
        {
            var requestModel = _fixture.Create<WeatherCity>();
            var context = new System.ComponentModel.DataAnnotations.ValidationContext(requestModel);
            requestModel.Temperature = temperature;
            var validationResults = new List<ValidationResult>();
            var result = Validator.TryValidateObject(requestModel, context, validationResults, true);

            var boolResult = validationResults.Any(x => x.MemberNames.Contains("Temperature"));


            Assert.True(boolResult);
        }

        [Theory]
        [InlineData(null)]
        public void City_CannotBeNull(string city)
        {
            var requestModel = _fixture.Create<WeatherCity>();
            requestModel.City = city;
            var validator = new WeatherCityValidator();
            validator.ShouldHaveValidationErrorFor(x => x.City, requestModel);
        }
    }
}
