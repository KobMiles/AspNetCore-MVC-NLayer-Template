using BLL.DTOs.Users;

namespace BLL.Interfaces.Services;

public interface IUserService
{
    Task<UserDetailsDto?> GetUserDetailsAsync(string userId);
}