using AutoMapper;
using WeatherApi.Models;
using WeatherApi.Services.Dtos;

namespace WeatherApi.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AccuWeatherResponseDto, ForecastResponse>()
                .ForMember(x => x.Headline, y => y.MapFrom(item => item.Headline.Text));
        }
    }
}
