namespace SurfThisUp.Models.Shared
{
    public class Location
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = "";
        public long Longitude { get; set; } = 0;
        public long Latitude { get; set; } = long.MaxValue;

    }
}
