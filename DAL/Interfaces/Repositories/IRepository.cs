using Ardalis.Specification;

namespace DAL.Interfaces.Repositories;

public interface IRepository<TEntity>
    : IRepositoryBase<TEntity>, IReadRepository<TEntity>
    where TEntity : class, IEntity
{

}