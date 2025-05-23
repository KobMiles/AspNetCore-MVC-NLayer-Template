﻿using BLL.DTOs.Users;
using Microsoft.AspNetCore.Identity;

namespace BLL.Interfaces.Services;

public interface IAuthService
{
    Task<IdentityResult> RegisterAsync(UserRegisterDto registerDto);

    Task<SignInResult> LoginAsync(UserLoginDto loginDto);

    Task LogoutAsync();
}