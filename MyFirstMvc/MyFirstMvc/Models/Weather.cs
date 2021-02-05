using System;

namespace MyFirstMvc.Models
{
    public class Weather
    {
        public DateTime Date { get; set; }
        public int High { get; set; }
        public int Low { get; set; }
        public string Description { get; set; }
    }
}