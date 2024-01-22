using Locadora.Dto;
using Locadora.Infra;
using Locadora.Interface;
using Locadora.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Locadora.Services
{
    public class TokenService : ITokenService
    {
        private IConfiguration _configuration;
        private ApplicationDbContext _context;

        public TokenService(IConfiguration configuration, ApplicationDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public async Task<string> GerarToken(LoginDto dto, CancellationToken cancellationToken)
        {
            var usuario = await VerificarUsusario(dto, cancellationToken);

            if (usuario == null)
                return string.Empty;

            var handler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = GerarClains(usuario),
                SigningCredentials = credentials,
                Expires = DateTime.UtcNow.AddHours(3),
                Issuer = issuer,
                Audience = audience
            };
            var token = handler.CreateToken(tokenDescriptor);

            return handler.WriteToken(token);
        }

        private static ClaimsIdentity GerarClains(Usuario usuario)
        {
            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.Name, usuario.Email));
            foreach (var item in usuario.Roles)
            {
                claims.AddClaim(new Claim(ClaimTypes.Role, item));
            }

            return claims;
        }

        private async Task<Usuario> VerificarUsusario(LoginDto dto, CancellationToken cancellationToken)
        {
            return await _context.Usuario.FirstOrDefaultAsync(x => x.Email == dto.Usuario && x.Senha == dto.Senha, cancellationToken);
        }
    }
}
