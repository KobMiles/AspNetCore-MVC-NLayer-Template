using Ardalis.Specification;

namespace DAL.Interfaces.Repositories;

public interface IEntityReadRepository<TEntity> : IReadRepositoryBase<TEntity>
    where TEntity : class
{
}