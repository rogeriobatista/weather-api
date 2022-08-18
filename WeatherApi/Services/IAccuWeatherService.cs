using WeatherApi.Services.Dtos;

namespace WeatherApi.Services
{
    public interface IAccuWeatherService
    {
        Task<AccuWeatherResponseDto> Get(int cityCode);
    }
}
