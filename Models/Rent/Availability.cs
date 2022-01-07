using SurfThisUp.Models.Shared;

namespace SurfThisUp.Models.Rent
{
    public class Availability
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public List<Date> Dates { get; set; } = new List<Date>();
    }
}
