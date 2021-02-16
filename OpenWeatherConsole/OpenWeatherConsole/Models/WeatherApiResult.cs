using Newtonsoft.Json;

namespace OpenWeatherConsole.Models
{
    public class WeatherApiResult
    {
        [JsonProperty("main")] public MainData Main { get; set; }
    }
}