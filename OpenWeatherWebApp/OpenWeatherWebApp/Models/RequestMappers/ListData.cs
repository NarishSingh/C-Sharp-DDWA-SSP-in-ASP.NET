using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenWeatherWebApp.Models.RequestMappers
{
    public class ListData
    {
        [JsonProperty("list")] public List<Forecast3hrData> ForecastList { get; set; }
        //TODO need to convert this to a ViewModel for Dictionary<DateTime, DayForecast> of 7 days, not a List of 3 hr block forecast's
    }
}