using SV.Core.Entities.Aeroportos;
using SV.Core.Entities.Base;
using System.Collections.Generic;

namespace SV.Core.Entities.Cidades
{
    public class Cidade : Entidade
    {
        public string Nome { get; private set; }
        public string Pais { get; private set; }
        public string Descricao { get; private set; }

        public ICollection<Aeroporto> Aeroportos { get; private set; }

        public Cidade(string nome, string pais, string descricao)
        {
            Nome = nome;
            Pais = pais;
            Descricao = descricao;
        }
    }
}
