using Microsoft.AspNetCore.Mvc;
using WeatherApi.Managers;
using WeatherApi.Models;

namespace WeatherApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForecastController : ControllerBase
    {
        private readonly IForecastManager _forecastManager;

        public ForecastController(IForecastManager forecastManager)
        {
            _forecastManager = forecastManager;
        }

        [HttpGet("{cityCode}")]
        public async Task<ActionResult<ForecastResponse>> Get(int cityCode)
        {
            var response = await _forecastManager.Get(cityCode);

            if (response != null)
                return Ok(response);

            return BadRequest(response);
        }
    }
}
