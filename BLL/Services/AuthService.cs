using AutoMapper;
using BLL.Constants;
using BLL.DTOs.Users;
using BLL.Interfaces.Services;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace BLL.Services;

public class AuthService(
    UserManager<User> userManager,
    SignInManager<User> signInManager,
    IMapper mapper) : IAuthService
{
    public async Task<IdentityResult> RegisterAsync(UserRegisterDto registerDto)
    {
        var user = mapper.Map<User>(registerDto);

        var createResult = await userManager.CreateAsync(user, registerDto.Password);
        if (!createResult.Succeeded)
            return createResult;


        var roleResult = await userManager.AddToRoleAsync(user, ApplicationRoles.User);
        if (!roleResult.Succeeded)
        {
            await userManager.DeleteAsync(user);

            return IdentityResult.Failed(roleResult.Errors.ToArray());
        }

        return createResult;
    }

    public async Task<SignInResult> LoginAsync(UserLoginDto loginDto)
    {
        var result = await signInManager.PasswordSignInAsync(
            loginDto.Email,
            loginDto.Password,
            loginDto.RememberMe,
            lockoutOnFailure: false
        );

        return result;
    }

    public async Task LogoutAsync()
    => await signInManager.SignOutAsync();
}