using WeatherApi.Services.Dtos;

namespace WeatherApi.Services
{
    public class AccuWeatherService : IAccuWeatherService
    {
        public async Task<AccuWeatherResponseDto> Get(int cityCode)
        {
            var httpClient = new HttpClient();

            var baseAddress = "https://dataservice.accuweather.com/forecasts/v1/daily/5day/";

            httpClient.BaseAddress = new Uri(baseAddress);

            const string apiKey = "Z1F1GUzpMaHfSKq7Qz3e7lqygFhPVliP";

            var url = $"{cityCode}?apikey={apiKey}&details=true";

            return await httpClient.GetFromJsonAsync<AccuWeatherResponseDto>(url);
        }
    }
}
