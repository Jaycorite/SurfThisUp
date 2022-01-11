using SurfThisUp.Models.Rent;

namespace SurfThisUp.Models.Shared
{
    public class Date
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime TheDate { get; set; } = DateTime.Now;
    }
}
