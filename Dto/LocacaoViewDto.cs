using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Locadora.Dto
{
    public record LocacaoViewDto
    {
        public int Id { get; set; }
        public DateTime DataRetirada { get; set; }
        public DateTime DataEntrega { get; set; }
        public int ClienteId { get; set; }
        public int VeiculoId { get; set; }
        public int LocadoraModeloId { get; set; }
        public int QuantidadeDiarias { get; set; }
        public int QuantidaDiariaMulta { get; set; }
        public string Observacao { get; set; }
        public string Veiculo { get; set; }
        public string Cliente { get; set; }
    }
}
