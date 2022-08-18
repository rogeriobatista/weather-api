using WeatherApi.Models;
using WeatherApi.Services;
using WeatherApi.Services.Dtos;

namespace WeatherApi.Managers
{
    public class ForecastManager : IForecastManager
    {
        private readonly IAccuWeatherService _accuWeatherService;

        public ForecastManager(IAccuWeatherService accuWeatherService)
        {
            _accuWeatherService = accuWeatherService;
        }

        public async Task<ForecastResponse> Get(int cityCode)
        {
            var forecastApiResponse = await _accuWeatherService.Get(cityCode);

            if (forecastApiResponse == null)
                return null;

            var forecastResponse = new ForecastResponse();

            forecastResponse.Headline = forecastApiResponse.Headline.Text;

            foreach (var item in forecastApiResponse.DailyForecasts)
            {
                var forecast = new Forecast
                {
                    Date = item.Date.ToShortDateString(),
                    Clothes = GetClothes(item.Temperature.Minimum.Value, item.Day, item.Night)
                };

                forecastResponse.Forecast.Add(forecast);
            }

            return forecastResponse;
        }

        private List<string> GetClothes(float temparature, AccuWeatherDailyForecastsProbability dayProbabilities, AccuWeatherDailyForecastsProbability nightProbabilities)
        {
            var clothes = new List<string>();

            if (temparature < 45)
            {
                clothes.AddRange(new List<string> { "Coat", "Winter jacket" });
            }
            else if (temparature >= 45 && temparature <= 79)
            {
                clothes.AddRange(new List<string> { "Fleece", "Short Sleeves" });
            }
            else if (temparature >= 80)
            {
                clothes.Add("Shorts");
            }

            if (dayProbabilities.RainProbability > 50 || nightProbabilities.RainProbability > 50)
            {
                clothes.Add("Rain Coat");
            }

            if (dayProbabilities.SnowProbability > 50 || nightProbabilities.SnowProbability > 50)
            {
                clothes.Add("Snow Outfit");
            }

            if (dayProbabilities.IceProbability > 50 || nightProbabilities.IceProbability > 50)
            {
                clothes.Add("Shell Jacket");
            }

            return clothes;
        }
    }
}
