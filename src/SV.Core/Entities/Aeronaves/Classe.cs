using SV.Core.Entities.Base;
using System.Collections.Generic;

namespace SV.Core.Entities.Aeronaves
{
    public class Classe : Entidade
    {
        public string Descricao { get; private set; }

        public ICollection<Assento> Assentos { get; private set; }

        public Classe(string descricao)
        {
            Descricao = descricao;
        }
    }
}
