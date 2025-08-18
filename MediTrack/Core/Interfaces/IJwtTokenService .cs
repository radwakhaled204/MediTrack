
using System.Security.Claims;
namespace MediTrack.Core.Interfaces
{
    public interface IJwtTokenService
    {
        public string GenerateJWT(IEnumerable<Claim> claims);

    }
}
