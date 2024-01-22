namespace Locadora.Dto
{
    public record VeiculoEditDto
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public string Cor { get; set; }
        public string Placa { get; set; }
    }
}
