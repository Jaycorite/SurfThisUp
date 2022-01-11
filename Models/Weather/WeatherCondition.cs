using SurfThisUp.Models.Shared;

namespace SurfThisUp.Models.Weather
{
    public class WeatherCondition
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public WaveCondition? WaveCondition { get; set; }
        public WindCondition? WindCondition { get; set; }
        public Location Location { get; set; } = new Location();
        public float Temp { get; set; } = -300f;
        public WeatherType WeatherType { get; set; } = WeatherType.Clear;
        public Date Date { get; set; } = new Date();
    }
}
