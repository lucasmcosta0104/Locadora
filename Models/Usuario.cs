using Locadora.Dto;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;

namespace Locadora.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required]
        public string NomeUsuario { get; set; }
        [Required]
        public string Senha { get; set; }
        [Required]
        public string[] Roles { get; set; }
        public int? LocadoraModeloId { get; set; }
        [JsonIgnore]
        public virtual LocadoraModelo LocadoraModelo { get; set; }

        public Task Adicionar(string usuario, string senha, string[] roles, int? locadoraModeloId)
        {
            NomeUsuario = usuario;  
            Senha = senha;
            Roles = roles;
            LocadoraModeloId = locadoraModeloId;
            return Task.CompletedTask;
        }

        public Task Editar(UsuarioDto dto)
        {
            NomeUsuario = dto.NomeUsuario;
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
