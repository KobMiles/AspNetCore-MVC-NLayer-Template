using AutoMapper;
using BLL.DTOs.Users;
using BLL.Interfaces.Services;
using DAL.Entities.Specifications.Users;
using DAL.Interfaces.Repositories;

namespace BLL.Services;

public class UserService(IUnitOfWork unitOfWork, IMapper mapper) : IUserService
{
    public async Task<UserDetailsDto?> GetUserDetailsAsync(string userId)
    {
        var spec = new UserByIdReadOnlySpec(userId);

        var user = await unitOfWork.Users.FirstOrDefaultAsync(spec);
        if (user == null)
            return null;

        var userDetailsDto = mapper.Map<UserDetailsDto>(user);

        return userDetailsDto;
    }
}