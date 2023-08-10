using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace parafia_mbkm.Services.IServices;

public interface ITokenService
{
    public string CreateToken(IdentityUser user);
}
