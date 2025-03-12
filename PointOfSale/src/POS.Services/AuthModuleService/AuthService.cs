﻿using Microsoft.EntityFrameworkCore;
using Pos.Repository.Data;
using Pos.Repository.Identity;
using POS.Contract.Dtos.AccountDtos;
using POS.Contract.Dtos.DineInDtos;
using POS.Core.Entities.Identity;

namespace POS.Services.AuthModuleService;

public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;
    private readonly AppDbContext _context;
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly AppIdentityDbContext _identityDbContext;

    public AuthService(IConfiguration configuration,
        AppDbContext context,
         UserManager<AppUser> userManager,
         RoleManager<IdentityRole> roleManager,
         AppIdentityDbContext identityDbContext
        )
    {
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
        _identityDbContext = identityDbContext;
        _configuration = configuration;
    }

    public async Task<bool> AddUserToRoleAsync(string userId, string roleName)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user is null)
            return false;

        var role = await _roleManager.FindByNameAsync(roleName);
        if (role is null)
            return false;

        var result = await _userManager.AddToRoleAsync(user, roleName);

        return result.Succeeded;
    }

    public async Task<bool> CreateRoleAsync(string roleName)
    {
        if (await _roleManager.RoleExistsAsync(roleName))
            return false;

        var result = await _roleManager.CreateAsync(new IdentityRole(roleName));

        return result.Succeeded;
    }

    public async Task<string> CreateTokenAsync(AppUser user, IList<string> roles, List<Claim> roleClaims)
    {
        var authClaims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user?.Id ?? string.Empty),
            new Claim(ClaimTypes.Name, user?.UserName ?? string.Empty),
            new Claim(ClaimTypes.NameIdentifier, user?.Id ?? string.Empty)
        };

        foreach (var role in roles)
        {
            authClaims.Add(new Claim(ClaimTypes.Role, role));
        }

        authClaims.AddRange(roleClaims); // ✅ Directly add role claims

        var secretKey = Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"] ?? string.Empty);
        var requiredKeyLength = 256 / 8;
        if (secretKey.Length < requiredKeyLength)
        {
            Array.Resize(ref secretKey, requiredKeyLength);
        }

        var token = new JwtSecurityToken(
            audience: _configuration["JWT:ValidAudience"],
            issuer: _configuration["JWT:ValidIssuer"],
            expires: DateTime.UtcNow.AddDays(double.Parse(_configuration["JWT:DurationInDays"] ?? "1")),
            claims: authClaims,
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature)
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }



    public async Task<AppUser?> CreateUserAsync(RegisterDto registerDto)
    {
        var user = new AppUser
        {
            UserName = registerDto.UserName,
            DisplayName = registerDto.DisplayName,
            Email = registerDto.Email,
            RegistrationDate = DateTime.Now,
            DateOfBirth = registerDto.DateOfBirth,
            //ImageUrl = registerDto!.ImageUrl!.FileName,
            ArabicName = registerDto.ArabicName
        };

        var result = await _userManager.CreateAsync(user, registerDto!.Password!);

        if (!result.Succeeded)
             return null;

        if (!await _roleManager.RoleExistsAsync(registerDto!.roleName!))
            return null;

        var result1 = await _userManager.AddToRoleAsync(user, registerDto!.roleName!);

        if (!result1.Succeeded)
            return null;

        return user;
    }

    public async Task<bool> DeleteRoleAsync(string roleName)
    {
        var role = await _roleManager.FindByNameAsync(roleName);
        if (role == null)
            return false;

        var result = await _roleManager.DeleteAsync(role);
        return result.Succeeded;
    }
    public async Task<bool> DeleteUserAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
            return false;

        var result = await _userManager.DeleteAsync(user);
        return result.Succeeded;
    }

    public async Task<List<IdentityRole>> GetAllRolesAsync()
    => _roleManager.Roles.ToList();

    public async Task<List<AppUser>> GetAllUsersAsync()
    => _userManager.Users.ToList();

    public async Task<IdentityRole> GetRoleAsync(string roleName)
    => await _roleManager.FindByNameAsync(roleName) ?? new();

    public async Task<AppUser> GetUserAsync(string userId)
    => await _userManager.FindByIdAsync(userId) ?? new();

    public async Task<bool> RemoveUserFromRoleAsync(string userId, string roleName)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
            return false;

        var result = await _userManager.RemoveFromRoleAsync(user, roleName);
        return result.Succeeded;
    }

    public async Task<bool> UpdateUserAsync(string userId, string newUserName, string newPassword, string newDisplayName, string newRole)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
            return false;

        // Update basic details
        user.UserName = newUserName;
        user.Email = newUserName;
        user.NormalizedUserName = newDisplayName;

        var updateResult = await _userManager.UpdateAsync(user);
        if (!updateResult.Succeeded)
            return false;

        if (!string.IsNullOrEmpty(newPassword))
        {
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var passwordResult = await _userManager.ResetPasswordAsync(user, token, newPassword);
            if (!passwordResult.Succeeded)
                return false;
        }

        var currentRoles = await _userManager.GetRolesAsync(user);
        if (currentRoles.Count > 0)
        {
            await _userManager.RemoveFromRolesAsync(user, currentRoles);
        }

        if (!await _roleManager.RoleExistsAsync(newRole))
        {
            await _roleManager.CreateAsync(new IdentityRole(newRole));
        }

        var roleResult = await _userManager.AddToRoleAsync(user, newRole);
        return roleResult.Succeeded;
    }



    public async Task<HashSet<string>> GetUserPermissionsAsync(ClaimsPrincipal user)
    {
        var appUser = await _userManager.GetUserAsync(user);
        if (appUser == null) return new HashSet<string>();

        // Get the roles associated with the user
        var roles = await _userManager.GetRolesAsync(appUser);

        if (roles.Count == 0) return new HashSet<string>();

        var role = await _roleManager.FindByNameAsync(roles[0]);
        if (role == null) return new HashSet<string>();


        var permissions = await _identityDbContext.RoleClaims
            .Where(rc => rc.RoleId == role.Id && rc.ClaimType == "Permission")
            .Select(rc => rc.ClaimValue)
            .Distinct()
            .ToListAsync();

        // Return the distinct permissions as a HashSet
        return new HashSet<string>(permissions!);
    }

    public async Task<List<AppUser>> GetUsersHasSpecificRole(string roleName)
    {
        var usersInRole = await _userManager.GetUsersInRoleAsync(roleName);

        return usersInRole.ToList();
    }
}