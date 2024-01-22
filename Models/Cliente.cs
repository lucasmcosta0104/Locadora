using Locadora.Dto;
using System.Text.Json.Serialization;

namespace Locadora.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Enedereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public bool Bloqueado { get; set; }
        public int LocadoraModeloId { get; set; }
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
