using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SurfThisUp.Models.Social;
using SurfThisUp.Models.Rent;
using SurfThisUp.Models.Weather;
using SurfThisUp.Models.Shared;
namespace SurfThisUp.Areas.Identity.Data;

public class SurfThisUpContext : IdentityDbContext<SurfThisUpUser>
{
    public SurfThisUpContext(DbContextOptions<SurfThisUpContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<RentalPost>().HasOne(x => x.Owner).WithMany(r => r.RentalPosts);
    }

    public DbSet<SocialPost> SocialPosts { get; set; }
    public DbSet<RentalPost> RentalPosts { get; set; }
    public DbSet<Rental> Rentals { get; set; }
    public DbSet<WeatherCondition> WeatherConditions { get; set; }
}
