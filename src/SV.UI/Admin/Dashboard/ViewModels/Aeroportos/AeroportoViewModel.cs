using SV.Application.InputModels.Aeroportos;
using System.Collections.Generic;

namespace SV.UI.Admin.Dashboard.ViewModels.Aeroportos
{
    public class AeroportoViewModel
    {
        public AeroportoInputModel AeroportoModel { get; set; }
        public IEnumerable<SV.Core.ViewModels.Cidades.CidadeViewModel> Cidades { get; set; }
    }
}
