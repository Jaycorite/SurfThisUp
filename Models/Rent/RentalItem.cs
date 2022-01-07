using SurfThisUp.Models.Shared;

namespace SurfThisUp.Models.Rent
{
    public class RentalItem
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = "";
        public string Description { get; set; } = string.Empty;
        public Condition Condition { get; set; } = Condition.Still_Safe;
        public List<Tag> Tags { get; set; } = new List<Tag>();
    }
}
