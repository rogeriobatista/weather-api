namespace WeatherApi.Models
{
    public class Forecast
    {
        public string Date { get; set; }
        public List<string> Clothes { get; set; } = new List<string>();
    }
}
