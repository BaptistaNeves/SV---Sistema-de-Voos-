using SV.Core.Entities.Base;
using SV.Core.Entities.Voos;
using System;

namespace SV.Core.Entities.Aeronaves
{
    public class Assento : Entidade
    {
        public int Numero { get; private set; }
        public Guid VooId { get; private set; }
        public Guid ClasseId { get; private set; }
        public bool Status { get; private set; }

        public Voo Voo { get; private set; }
        public Classe Classe { get; private set; }

        public Assento(int numero, Guid vooId, Guid classeId)
        {
            Numero = numero;
            VooId = vooId;
            ClasseId = classeId;
        }

        public void AlterarStatusAssento()
        {
            Status = true;
        }

        public void ReporStatusAssento()
        {
            Status = false;
        }
    }
}
