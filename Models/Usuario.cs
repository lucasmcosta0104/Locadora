using Locadora.Dto;
using System.Security.Cryptography;
using System.Text;

namespace Locadora.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string[] Roles { get; set; }

        public Task Adicionar(string email, string senha, string[] roles)
        {
            Email = email;  
            Senha = senha;
            Roles = roles;

            return Task.CompletedTask;
        }

        public Task Editar(UsuarioDto dto)
        {
            Email = dto.Email;
            Senha = dto.Senha;
            if(dto.CodigoAdministrador == "admin")
                Roles[0] = "admin";

            return Task.CompletedTask;
        }

        public Task DefinirAdministrador()
        {
            Roles[0] = "admin";

            return Task.CompletedTask;
        }
    }
}
