using SV.Core.Entities.Base;
using SV.Core.Entities.Voos;
using System;

namespace SV.Core.Entities.Reservas
{
    public class Reserva : Entidade
    {
        public Guid VooId { get; private set; }
        public Guid AssentoId { get; private set; }
        public double Preco { get; private set; }

        public string Nome { get; private set; }
        public string TipoDocumento { get; private set; }
        public string NumeroDocumento { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
        public string Endereco { get; private set; }
        public string Sexo { get; private set; }
        public DateTime DataNascimento { get; private set; }

        public Voo Voo { get; set; }
    }
}
