using System;

namespace SV.Core.DTOs.Usuarios
{
    public class UsuarioDto
    {
        public Guid Id { get; set; }
        public string NomeDeUtilizador { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Perfil { get; set; }
    }
}
