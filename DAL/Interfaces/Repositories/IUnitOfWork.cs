namespace DAL.Interfaces.Repositories;

public interface IUnitOfWork : IDisposable
{
    IUserRepository Users { get; }

    int Save();
    Task<int> SaveAsync();
}