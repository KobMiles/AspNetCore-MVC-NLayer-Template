using Ardalis.Specification;

namespace DAL.Entities.Specifications.Users;

public sealed class UserByIdSpec : Specification<User>
{
    public UserByIdSpec(string userId)
    {
        Query.Where(u => u.Id == userId);
    }
}