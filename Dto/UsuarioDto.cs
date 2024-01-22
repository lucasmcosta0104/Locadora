namespace Locadora.Dto
{
    public record UsuarioDto
    {
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
        public int? LocadoraModeloId { get; set; }
        public string CodigoAdministrador { get; set; }
    }
}
