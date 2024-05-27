using Microsoft.AspNetCore.Identity;

namespace tracker.api.Repositories
{
    public interface InterfaceTokenRepository
    {
       string CreateJWT(IdentityUser user , List<string> roles);
    }
}
