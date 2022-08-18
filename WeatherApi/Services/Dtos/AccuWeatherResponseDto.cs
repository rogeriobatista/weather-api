namespace WeatherApi.Services.Dtos
{
    public class AccuWeatherResponseDto
    {
        public AccuWeatherHeadline Headline { get; set; }
        public List<AccuWeatherDailyForecasts> DailyForecasts { get; set; }
    }

    public class AccuWeatherHeadline
    {
        public string Text { get; set; }
    }

    public class AccuWeatherDailyForecasts
    {
        public DateTime Date { get; set; }
        public AccuWeatherDailyForecastsTemparature Temperature { get; set; }
        public AccuWeatherDailyForecastsProbability Day { get; set; }
        public AccuWeatherDailyForecastsProbability Night { get; set; }
    }

    public class AccuWeatherDailyForecastsTemparature
    {
        public AccuWeatherDailyForecastsTemparatureValue Minimum { get; set; }
        public AccuWeatherDailyForecastsTemparatureValue Maximum { get; set; }
    }

    public class AccuWeatherDailyForecastsTemparatureValue
    {
        public float Value { get; set; }
    }

    public class AccuWeatherDailyForecastsProbability
    {
        public int RainProbability { get; set; }
        public int SnowProbability { get; set; }
        public int IceProbability { get; set; }
    }
}
