using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SlagModeServer.DTOs;
using SlagModeServer.entities.NewStructure;
using SlagModeServer.Services;

public class AuthService
{
    private readonly IConfiguration _config;
    private readonly SlagSolverDbContext _dbContext;

    public AuthService(IConfiguration config, SlagSolverDbContext dbContext)
    {
        _config = config;
        _dbContext = dbContext;
    }

    public async Task<string?> Authenticate(UserAuthorisationData userData)
    {
        var userStoredData = await _dbContext.Users
            .FirstOrDefaultAsync(x => x.Login == userData.UserName);

        if (userStoredData == null)
            return null;

        if (!BCrypt.Net.BCrypt.Verify(userData.Password, userStoredData.Password))
            return null;

        return GenerateJwtToken(userStoredData);
    }

    private string GenerateJwtToken(Users user)
    {
        var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Login),
            new Claim(ClaimTypes.NameIdentifier, user.UserID.ToString()),
        };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

/*    public bool HashLockPasswords()
    {
        var users = _dbContext.Users.ToList();
        foreach (var user in users)
        {
            if (!user.Password.StartsWith("$2a$"))
            {
                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            }
        }
        _dbContext.SaveChanges();
        return true;
    }*/
}
