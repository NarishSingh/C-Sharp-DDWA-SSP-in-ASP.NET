using Newtonsoft.Json;

namespace OpenWeatherWebApp.Models.RequestMappers
{
    public class WindData
    {
        [JsonProperty("speed")] public decimal Speed { get; set; }
        [JsonProperty("deg")] public decimal Degree { get; set; }
    }
}