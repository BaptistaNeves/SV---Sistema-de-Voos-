using SV.Core.Entities.Base;

namespace SV.Core.Entities.Usuarios
{
    public class Usuario : Entidade
    {
        public string Nome { get; set; }
        public string NomeDeUtilizador { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Perfil { get; set; }
        public string Senha { get; set; }
        public string SenhaAntiga { get; set; }
    }
}
