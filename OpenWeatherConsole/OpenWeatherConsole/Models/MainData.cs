using Newtonsoft.Json;

namespace OpenWeatherConsole.Models
{
    public class MainData
    {
        [JsonProperty("temp")] public decimal Temp { get; set; }
        
        [JsonProperty("humidity")] public decimal Humidity { get; set; }
        
        [JsonProperty("pressure")] public decimal Pressure { get; set; }
    }
}