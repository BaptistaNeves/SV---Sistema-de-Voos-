using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SV.Core.DTOs.Reservas
{
    public class ReservaDto
    {
        public Guid Id { get; set; }
        public string Voo { get; set; }
        public string Assento { get; set; }
        public double Preco { get; set; }

        public string Nome { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
