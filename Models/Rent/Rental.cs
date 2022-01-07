using SurfThisUp.Areas.Identity.Data;

namespace SurfThisUp.Models.Rent
{
    public class Rental
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        RentalPost RentalPost { get; set; }
        SurfThisUpUser Rentee { get; set; }
    }
}
