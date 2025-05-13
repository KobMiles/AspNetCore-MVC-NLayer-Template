using Ardalis.Specification;

namespace DAL.Interfaces.Repositories;

public interface IEntityRepository<TEntity>
    : IRepositoryBase<TEntity>, IEntityReadRepository<TEntity>
    where TEntity : class, IEntity
{

}