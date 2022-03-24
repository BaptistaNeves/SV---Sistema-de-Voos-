using SV.Core.Entities.Base;
using System.Collections.Generic;

namespace SV.Core.Entities.Funcionarios
{
    public class CategoriaFuncionario : Entidade
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }

        public IEnumerable<Funcionario> Funcionarios { get; private set; }
    }
}
