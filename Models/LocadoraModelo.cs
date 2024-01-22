using Locadora.Dto;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Locadora.Models
{
    public class LocadoraModelo
    {
        public int Id { get; private set; }
        [Required]
        public string Nome { get; private set; }
        [Required]
        public string CNPJ { get; private set; }
        [Required]
        public string Endereco { get; private set; }
        [Required]
        public string Telefone { get; private set; }
        [Required]
        public string Email { get; private set; }
        public string Segmento { get; private set; }
        [JsonIgnore]
        public virtual ICollection<Cliente> Clientes { get; private set; }
        [JsonIgnore]
        public virtual ICollection<Veiculo> Veiculos { get; private set; }
        [JsonIgnore]
        public virtual ICollection<Locacao> Locacoes { get; private set; }
        [JsonIgnore]
        public virtual ICollection<Usuario> Usuarios { get; private set; }

        public Task Adicionar(LocadoraDto dto)
        {
            Nome = dto.Nome;
            CNPJ = dto.CNPJ;
            Endereco = dto.Endereco;
            Telefone = dto.Telefone;
            Email = dto.Email;
            Segmento = dto.Segmento;

            return Task.CompletedTask;
        }

        public Task Editar(LocadoraDto dto)
        {
            Nome = dto.Nome;
            CNPJ = dto.CNPJ;
            Endereco = dto.Endereco;
            Telefone = dto.Telefone;
            Email = dto.Email;
            Segmento = dto.Segmento;

            return Task.CompletedTask;
        }
    }
}
