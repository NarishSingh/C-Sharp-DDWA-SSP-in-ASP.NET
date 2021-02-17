using Newtonsoft.Json;

namespace OpenWeatherWebApp.Models.RequestMappers
{
    public class WeatherData
    {
        [JsonProperty("main")] public string Condition { get; set; }
        [JsonProperty("description")] public string ConditionDescription { get; set; }
        [JsonProperty("icon")] public int IconId { get; set; }
        //TODO figure out icon, uses GET request to 'http://openweathermap.org/img/w/' + iconId + '.png'
    }
}