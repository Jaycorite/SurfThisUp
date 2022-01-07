using SurfThisUp.Models.Shared;

namespace SurfThisUp.Models.Weather
{
    public class WeatherCondition
    {
        public string Id { get; set; }
        public WaveCondition WaveCondition { get; set; }
        public WindCondition WindCondition { get; set; }
        public Location Location { get; set; }
        public float Temp { get; set; }
        public WeatherType WeatherType { get; set; }
        public Date Date { get; set; }
    }
}
