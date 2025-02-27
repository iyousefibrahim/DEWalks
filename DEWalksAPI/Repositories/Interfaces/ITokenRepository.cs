using Microsoft.AspNetCore.Identity;

namespace DEWalksAPI.Repositories.Interfaces
{
    public interface ITokenRepository
    {
        string CreateJwtToken(IdentityUser user,List<string> roles);
    }
}
