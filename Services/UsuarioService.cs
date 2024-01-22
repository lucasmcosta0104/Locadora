using Locadora.Dto;
using Locadora.Interface;
using Locadora.Models;

namespace Locadora.Services
{
    public class UsuarioService
    {
        private readonly IConfiguration _configuration;
        private readonly IRepository<Usuario> _repository;
        public UsuarioService(IConfiguration configuration, IRepository<Usuario> repository)
        {
            _configuration = configuration;
            _repository = repository;
        }

        public async Task AdicionarUsuario(UsuarioDto dto, CancellationToken cancellationToken)
        {
            var usuario = new Usuario();
            var usuarioAdministrador = _configuration.GetSection("appsettings").GetValue<string>("Administrador") == dto.CodigoAdministrador;
            await usuario.Adicionar(dto.Email, dto.Senha, usuarioAdministrador ?["admin"] : ["padrao"]);
            await _repository.Add(usuario, cancellationToken);
        }

        public async Task<Usuario> BuscarUsuario(int id, CancellationToken cancellationToken)
        {
            return await _repository.Find(id, cancellationToken);
        }

        public async Task RemoverUsuario(int id, CancellationToken cancellationToken)
        {
            var usuario = await _repository.Find(id, cancellationToken);

            if (usuario == null)
                throw new Exception("Usuário não foi encontrado");

            await _repository.Delete(usuario, cancellationToken);
        }

        public async Task EditarUsuario(int id, UsuarioDto dto, CancellationToken cancellationToken)
        {
            var usuario = await _repository.Find(id, cancellationToken);
            if (usuario == null)
                throw new Exception("Usuário não foi encontrado");

            await usuario.Editar(dto);

            await _repository.Update(usuario, cancellationToken);
        }

        public async Task<ICollection<Usuario>> BuscaCompleta(CancellationToken cancellationToken)
        {
            return await _repository.All(cancellationToken);
        }

        public async Task DefinirAdministrador(int id, CancellationToken cancellationToken)
        {
            var usuario = await _repository.Find(id, cancellationToken);
            if (usuario == null)
                throw new Exception("Usuário não foi encontrado");

            await usuario.DefinirAdministrador();
            await _repository.Update(usuario, cancellationToken);
        }
    }
}
