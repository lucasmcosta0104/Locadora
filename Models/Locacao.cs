using Locadora.Dto;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Locadora.Models
{
    public class Locacao
    {
        public int Id { get; set; }
        [Required]
        public DateTime DataRetirada { get; private set; }
        public DateTime DataEntrega { get; private set; }
        [Required]
        public int ClienteId { get; private set; }
        [Required]
        public int VeiculoId { get; private set; }
        [Required]
        public int LocadoraModeloId { get; private set; }
        [Required]
        public int QuantidadeDiarias { get; private set; }
        public int QuantidaDiariaMulta { get; private set; }
        public string Observacao { get; private set; }
        [JsonIgnore]
        public virtual Veiculo Veiculo { get; private set; }
        [JsonIgnore]
        public virtual Cliente Cliente { get; private set; }
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
