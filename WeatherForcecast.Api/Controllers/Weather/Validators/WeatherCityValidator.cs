using FluentValidation;
using Weather.Api.Controllers.Weather.Requests;

namespace Weather.Api.Controllers.Weather.Validators
{
    public class WeatherCityValidator : AbstractValidator<WeatherCity>
    {
        public WeatherCityValidator()
        {
            RuleFor(x => x.City)
                .NotNull().WithMessage("City cannot be null");

        }
    }
}

