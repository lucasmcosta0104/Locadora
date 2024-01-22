using System.ComponentModel.DataAnnotations;

namespace Locadora.Dto
{
    public record LocacaoDto
    {
        public DateTime DataRetirada { get; set; }
        public int ClienteId { get; set; }
        public int VeiculoId { get; set; }
        public int LocadoraModeloId { get; set; }
        public int QuantidadeDiarias { get; set; }
        public string Observacao { get; set; }
    }
}
