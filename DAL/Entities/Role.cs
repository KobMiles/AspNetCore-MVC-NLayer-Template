using Microsoft.AspNetCore.Identity;

namespace DAL.Entities;

public class Role : IdentityRole
{
    public Role(string roleName) : base(roleName)
    {
    }

    public Role()
    {
    }
}
