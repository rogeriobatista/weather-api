using WeatherApi.Models;

namespace WeatherApi.Managers
{
    public interface IForecastManager
    {
        Task<ForecastResponse> Get(int cityCode);
    }
}
