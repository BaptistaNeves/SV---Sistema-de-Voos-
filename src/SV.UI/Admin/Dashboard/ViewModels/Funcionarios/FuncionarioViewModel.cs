using SV.Application.InputModels.Funcionarios;
using SV.Core.Entities.Funcionarios;
using System.Collections.Generic;

namespace SV.UI.Admin.Dashboard.ViewModels.Funcionarios
{
    public class FuncionarioViewModel
    {
        public FuncionarioInputModel FuncionarioModel { get; set; }
        public IEnumerable<CategoriaFuncionario> Categorias { get; set; }
    }
}
