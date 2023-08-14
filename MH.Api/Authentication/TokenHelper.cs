using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MH.Domain.Constant;
using MH.Domain.DBModel;
using Microsoft.IdentityModel.Tokens;

namespace MH.Api.Authentication;

public class TokenHelper
{
    private readonly IConfiguration _configuration;

    public TokenHelper(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<string> GetToken(ApplicationUser user, IList<string> userRoles)
    {
        var authClaims = new List<Claim>
        {
            new(ClaimConstant.Id, user.Id.ToString()),
            new(ClaimConstant.UserName, user.UserName),
            new(ClaimConstant.FirstName, user.UserProfile.FirstName),
            new(ClaimConstant.LastName, user.UserProfile.LastName),
            new(ClaimConstant.Email, user.Email ?? ""),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        foreach (var userRole in userRoles) authClaims.Add(new Claim(ClaimTypes.Role, userRole));

        //TODO** Magic Word Should Be Replaced By Constant
        var authSigningKey =
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"] ?? string.Empty));
        var token = new JwtSecurityToken(
            _configuration["JWT:ValidIssuer"],
            _configuration["JWT:ValidAudience"],
            expires: DateTime.Now.AddHours(Convert.ToInt16(_configuration["JWT:TokenValidityInHour"])),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        );
        return await Task.Run(() => new JwtSecurityTokenHandler().WriteToken(token));
    }

    public async Task<List<string>> ValidateToken(string token)
    {
        var roles = new List<string>();
        if (token == null)
            return null;

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]);
        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            }, out var validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            var userId = int.Parse(jwtToken.Claims.First(x => x.Type == ClaimConstant.Id).Value);
            if (userId <= 0) return null;

            foreach (var item in jwtToken.Claims)
                switch (item.Type)
                {
                    case ClaimTypes.Role:
                        roles.Add(item.Value);
                        break;
                }

            return roles;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}