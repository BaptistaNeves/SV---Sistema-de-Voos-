using SV.Core.Entities.Base;
using System;
using System.Collections.Generic;

namespace SV.Core.Entities.Voos
{
    public class TipoDeVoo : Entidade
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }

        public ICollection<Voo> Voos { get; set; }

        public TipoDeVoo(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
        }
    }
}
