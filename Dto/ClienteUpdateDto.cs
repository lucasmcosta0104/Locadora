namespace Locadora.Dto
{
    public record ClienteUpdateDto
    {
        public string Enedereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }
}
