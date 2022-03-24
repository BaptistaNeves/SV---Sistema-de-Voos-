using SV.Application.InputModels.Cidades;
using SV.Core.Entities.Cidades;
using System.Collections.Generic;

namespace SV.UI.Admin.Dashboard.ViewModels
{
    public class CidadeViewModel
    {
        public IEnumerable<Cidade> Cidades { get; set; }
        public CidadeInputModel CidadeInputModel { get; set; }
    }
}
