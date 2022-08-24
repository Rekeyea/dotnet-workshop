namespace Services;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Configuration.Models;
using Dtos;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

public class AuthService
{
    public AuthService(UserManager<IdentityUser> userManager, JwtConfiguration jwtConfiguration)
    {
        UserManager = userManager;
        JwtConfiguration = jwtConfiguration;
    }

    public UserManager<IdentityUser> UserManager { get; }
    public JwtConfiguration JwtConfiguration { get; }

    public async Task<RegisterResponse> Register(RegisterModel model)
    {
        var user = await this.UserManager.FindByEmailAsync(model.Email);
        if (user is not null)
        {
            throw new Exception("User already exists");
        }

        user = new IdentityUser
        {
            Email = model.Email,
            UserName = model.Email,
            SecurityStamp = Guid.NewGuid().ToString()
        };

        var result = await this.UserManager.CreateAsync(user, model.Password);
        if (!result.Succeeded)
        {
            throw new Exception(string.Join('.', result.Errors.Select(x => x.Description)));
        }

        return user.Adapt<RegisterResponse>();
    }

    public async Task<LoginResponse> Login(LoginModel model)
    {
        var user = await this.UserManager.FindByEmailAsync(model.Email);
        if (user is not null)
        {
            var checkedPassword = await this.UserManager.CheckPasswordAsync(user, model.Password);
            if (checkedPassword)
            {
                var roles = await this.UserManager.GetRolesAsync(user);
                var cls = await this.UserManager.GetClaimsAsync(user);

                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.UserName ?? string.Empty)
                    };
                claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));
                claims.AddRange(cls);

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.JwtConfiguration.Secret));

                var token = new JwtSecurityToken(
                    issuer: this.JwtConfiguration.ValidIssuer,
                    audience: this.JwtConfiguration.ValidAudience,
                    expires: DateTime.Now.AddHours(3),
                    claims: claims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                var tokenResponse = new JwtSecurityTokenHandler().WriteToken(token);
                return new LoginResponse(tokenResponse);
            }
        }

        throw new Exception("Invalid Credentials");
    }
}