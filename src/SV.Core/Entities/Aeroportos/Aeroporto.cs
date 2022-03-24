using SV.Core.Entities.Base;
using SV.Core.Entities.Cidades;
using System;

namespace SV.Core.Entities.Aeroportos
{
    public class Aeroporto : Entidade
    {
        public string Nome { get; private set; }
        public Guid CidadeId { get; private set; }
        public bool Activo { get; private set; }

        public Cidade Cidade { get; private set; }

        public Aeroporto(string nome, Guid cidadeId, bool activo)
        {
            Nome = nome;
            CidadeId = cidadeId;
            Activo = activo;
        }
    }
}
