using Locadora.Dto;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Locadora.Models
{
    public class Cliente
    {
        public int Id { get; private set; }
        [Required]
        public string Nome { get;private  set; }
        [Required]
        public string CPF { get; private set; }
        [Required]
        public string RG { get; private set; }
        [Required]
        public string Enedereco { get; private set; }
        [Required]
        public string Telefone { get; private set; }
        [Required]
        public string Email { get; private set; }
        public bool Bloqueado { get; private set; }
        public int LocadoraModeloId { get; private set; }
        [JsonIgnore]
        public virtual LocadoraModelo LocadoraModelo { get; private set; }
        [JsonIgnore]
        public virtual ICollection<Locacao> Locacoes { get; private set; }

        public Task Adicionar(ClienteDto dto)
        {
            Nome = dto.Nome;
            CPF = dto.CPF;
            RG = dto.RG;
            Enedereco = dto.Enedereco;
            Telefone = dto.Enedereco;
            Email = dto.Email;
            LocadoraModeloId = dto.IdLocadora;
            Bloqueado = false;
            
            return Task.CompletedTask;
        }

        public Task Editar(ClienteUpdateDto dto)
        {
            Enedereco = dto.Enedereco;
            Telefone = dto.Enedereco;
            Email = dto.Email;

            return Task.CompletedTask;
        }

        public Task Bloquear()
        {
            Bloqueado = true;
            return Task.CompletedTask;
        }

        public Task Desbloquear()
        {
            Bloqueado = false;
            return Task.CompletedTask;
        }
    }
}
