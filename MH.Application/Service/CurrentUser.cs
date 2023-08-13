using System.Security.Claims;
using MH.Domain.Constant;
using MH.Domain.IEntity;
using MH.Domain.DBModel;
using Microsoft.AspNetCore.Http;

namespace MH.Application.Service;

public class CurrentUser : ICurrentUser
{
    private readonly IHttpContextAccessor _accessor;
    public CurrentUser(IHttpContextAccessor accessor)
    {
        _accessor = accessor;
    }

    //todo: Create ext method to on claim type
    private Claim? GetClaim(string claimConstant) =>
        _accessor.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == claimConstant);
    private int GetClaimId => Convert.ToInt32(GetClaim(ClaimConstant.Id)?.Value);
    private string? GetClaimUsername => GetClaim(ClaimConstant.UserName)?.Value;
    private string? GetClaimFirstName => GetClaim(ClaimConstant.Name)?.Value;
    private string? GetClaimEmail => GetClaim(ClaimConstant.Email)?.Value;
  
    public ApplicationUser User => new()
    {
        Id = GetClaimId,
        UserName = GetClaimUsername,
        NormalizedUserName = GetClaimFirstName,
        Email = GetClaimEmail
    };

}