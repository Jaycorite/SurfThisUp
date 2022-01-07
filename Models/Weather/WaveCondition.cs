namespace SurfThisUp.Models.Weather
{
    public class WaveCondition
    {
        public string Id { get; set; }
        public float MaxWaveHeight { get; set; }
        public float SigWaveHeight { get; set;}
        public float MaxWavePeriod { get; set; }
        public float SigWavePeriod { get; set; }
        public float Direction { get; set; }
    }
}
