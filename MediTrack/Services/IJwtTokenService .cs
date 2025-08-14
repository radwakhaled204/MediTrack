
using System.Security.Claims;
namespace MediTrack.Services
{
    public interface IJwtTokenService
    {
        public string GenerateJWT(IEnumerable<Claim> claims);

    }
}
