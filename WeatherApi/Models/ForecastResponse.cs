namespace WeatherApi.Models
{
    public class ForecastResponse
    {
        public string Headline { get; set; }
        public List<Forecast> Forecast { get; set; } = new List<Forecast>();
    }
}
