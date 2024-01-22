using Locadora.Dto;
using System.Security.Claims;

namespace Locadora.Interface
{
    public interface ITokenService
    {
        Task<string> GerarToken(LoginDto usuario, CancellationToken cancellationToken);
        int? RetornaIdLocadora(ClaimsPrincipal user);
    }
}
