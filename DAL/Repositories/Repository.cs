using Microsoft.EntityFrameworkCore;
using Ardalis.Specification.EntityFrameworkCore;
using DAL.Interfaces;
using DAL.Interfaces.Repositories;

namespace DAL.Repositories;

public class Repository<TEntity>(DbContext context)
    : RepositoryBase<TEntity>(context), IRepository<TEntity>
    where TEntity : class, IEntity
{

}