using SV.Core.Entities.Base;
using System;

namespace SV.Core.Entities.Aeronaves
{
    public class Assento : Entidade
    {
        public int Numero { get; private set; }
        public Guid AeronaveId { get; private set; }
        public Guid ClasseId { get; private set; }

        public Aeronave Aeronave { get; private set; }
        public Classe Classe { get; private set; }

        public Assento(int numero, Guid aeronaveId, Guid classeId)
        {
            Numero = numero;
            AeronaveId = aeronaveId;
            ClasseId = classeId;
        }
    }
}
