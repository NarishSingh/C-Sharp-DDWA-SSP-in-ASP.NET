using System;
using System.Net.Http;
using OpenWeatherConsole.Models;

namespace OpenWeatherConsole
{
    internal class Program
    {
        private static void WeatherSearch(string zipcode)
        {
            //key and model decl -> model starts null, Json converter will instantiate and populate
            string apiKey = "f29ed23e97e67d948334f9b71c66421d";
            WeatherApiResult model = null;

            //HttpClient
            HttpClient client = new HttpClient();
            
            //URI to make request to -> will use Query Strings
            string uri = $"http://api.openweathermap.org/data/2.5/weather?" +
                         $"zip={zipcode},us&units=imperial&appid={apiKey}";
            
            //Send async GET to uri using HttpClient
            //-> wait for response, continue with processing JSON from response body
            var task = client.GetAsync(uri)
                .ContinueWith((taskForResponse) =>
                {
                    HttpResponseMessage response = taskForResponse.Result;

                    //response body content is bound from JSON to C# obj
                    var processJson = response.Content.ReadAsAsync<WeatherApiResult>();
                    processJson.Wait();

                    model = processJson.Result;
                });

            task.Wait(); //all the Wait()'s are due to async execution

            DisplaySearchResults(model);
        }

        private static void DisplaySearchResults(WeatherApiResult model)
        {
            Console.WriteLine($"Temperature (F): {model.Main.Temp}");
            Console.WriteLine($"Humidity: {model.Main.Humidity}");
            Console.WriteLine($"Pressure: {model.Main.Pressure}");
            Console.WriteLine("\nPress any key to continue. . .");
            Console.ReadKey();
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Enter a zip code: ");
            string zip = Console.ReadLine();


            WeatherSearch(zip);
        }
    }
}