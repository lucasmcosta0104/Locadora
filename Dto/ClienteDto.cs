namespace Locadora.Dto
{
    public record ClienteDto
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Enedereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int IdLocadora { get; set; }
    }
}
