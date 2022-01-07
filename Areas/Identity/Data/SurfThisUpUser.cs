using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SurfThisUp.Models.Rent;
using SurfThisUp.Models.Social;

namespace SurfThisUp.Areas.Identity.Data;

// Add profile data for application users by adding properties to the SurfThisUpUser class
public class SurfThisUpUser : IdentityUser
{
    [PersonalData]
    public string Name { get; set; } = "John doe";
    [PersonalData]
    public string Address { get; set; } = string.Empty;
    [PersonalData]
    public string? ProfilePicPath { get; set; }
    public int Rating { get; set; } = 0;
    public List<SocialPost>? Posts { get; set; }
    public List<RentalPost>? RentalPosts { get; set; }

    public List<Rental>? Rentals { get; set; }
}

