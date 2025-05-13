using Ardalis.Specification;

namespace DAL.Entities.Specifications.Users;

public sealed class UserByIdReadOnlySpec : Specification<User>
{
    public UserByIdReadOnlySpec(string userId)
    {
        Query.Where(u => u.Id == userId)
            .AsNoTracking();
    }
}