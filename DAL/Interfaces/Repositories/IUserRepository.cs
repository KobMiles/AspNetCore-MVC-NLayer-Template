using Ardalis.Specification;
using DAL.Entities;

namespace DAL.Interfaces.Repositories;

public interface IUserRepository
    : IRepositoryBase<User>, IReadRepository<User>
{
}