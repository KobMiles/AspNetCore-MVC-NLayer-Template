using Ardalis.Specification.EntityFrameworkCore;
using DAL.Entities;
using DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class UserRepository(DbContext context)
    : RepositoryBase<User>(context), IUserRepository
{

}