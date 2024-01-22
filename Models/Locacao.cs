using Locadora.Dto;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Locadora.Models
{
    public class Locacao
    {
        public int Id { get; set; }
        [Required]
        public DateTime DataRetirada { get; set; }
        public DateTime DataEntrega { get; set; }
        [Required]
        public int ClienteId { get; set; }
        [Required]
        public int VeiculoId { get; set; }
        [Required]
        public int LocadoraModeloId { get; set; }
        [Required]
        public int QuantidadeDiarias { get; set; }
        public int QuantidaDiariaMulta { get; set; }
        public string Observacao { get; set; }
        [JsonIgnore]
        public virtual Veiculo Veiculo { get; set; }
        [JsonIgnore]
        public virtual Cliente Cliente { get; set; }
        [JsonIgnore]
        public virtual LocadoraModelo LocadoraModelo { get; set; }

        public Task Alugar(LocacaoDto dto)
        {
            DataRetirada = dto.DataRetirada;
            ClienteId = dto.ClienteId;
            VeiculoId = dto.VeiculoId;
            LocadoraModeloId = dto.LocadoraModeloId;
            QuantidadeDiarias = dto.QuantidadeDiarias;
            Observacao = dto.Observacao;

            return Task.CompletedTask;
        }

        public int Entregar()
        {
            DataEntrega = DateTime.Now;
            var diarias = (DataEntrega.Day - DataRetirada.Day);
            if (diarias - QuantidadeDiarias > 0)
            {
                QuantidaDiariaMulta = diarias - QuantidadeDiarias;
            }

            return diarias;
        }
    }
}
