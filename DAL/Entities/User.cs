using Microsoft.AspNetCore.Identity;

namespace DAL.Entities;

public class User : IdentityUser
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
}