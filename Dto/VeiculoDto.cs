namespace Locadora.Dto
{
    public record VeiculoDto
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public string Cor { get; set; }
        public string Placa { get; set; }
        public decimal ValorDiaria { get; set; }
        public int LocadoraModeloId { get; set; }
    }
}
