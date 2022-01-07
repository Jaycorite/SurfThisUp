using SurfThisUp.Areas.Identity.Data;
using SurfThisUp.Models.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurfThisUp.Models.Rent
{
    public class RentalPost
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Titel { get; set; } = string.Empty;
        public string Description { get; set; } = "";
        public Location? Location { get; set; } = null;
        [Required]
        public SurfThisUpUser Owner { get; set; } = new();
        public List<Tag> Tags { get; set; } = new List<Tag>();
        public Category Category { get; set; } = new();
        public RentalItem RentalItem { get; set; } = new RentalItem();
        public float Price { get; set; } = 0f;
        public List<ResourcePath> ResourcePaths { get; set; } = new List<ResourcePath> { };
        public Availability Availability { get; set; } = new Availability();

        
    }
}
