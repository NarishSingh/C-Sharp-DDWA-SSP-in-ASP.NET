using System;
using Newtonsoft.Json;

namespace OpenWeatherWebApp.Models.RequestMappers
{
    public class Forecast3hrData
    {
        [JsonProperty("dt_txt")] public DateTime StartDateTime { get; set; }
        [JsonProperty("main")] public MainData Main { get; set; }
        [JsonProperty("weather")] public WeatherData Weather { get; set; }
        [JsonProperty("wind")] public WindData Wind { get; set; }
    }
}