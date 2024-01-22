using Locadora.Dto;

namespace Locadora.Interface
{
    public interface ITokenService
    {
        Task<string> GerarToken(LoginDto usuario, CancellationToken cancellationToken);
    }
}
