using Newtonsoft.Json;

namespace OpenWeatherWebApp.Models.RequestMappers
{
    public class MainData
    {
        [JsonProperty("temp")] public decimal Temp { get; set; }
        [JsonProperty("pressure")] public decimal Pressure { get; set; }
        [JsonProperty("humidity")] public decimal Humidity { get; set; }
    }
}