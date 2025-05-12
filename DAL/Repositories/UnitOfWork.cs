using DAL.Data;
using DAL.Interfaces.Repositories;

namespace DAL.Repositories;

public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
{
    private IUserRepository? _users;
    public IUserRepository Users
        => _users ??= new UserRepository(context);

    public int Save() => context.SaveChanges();
    public async Task<int> SaveAsync() => await context.SaveChangesAsync();

    public void Dispose()
    {
        context.Dispose();
        GC.SuppressFinalize(this);
    }
}