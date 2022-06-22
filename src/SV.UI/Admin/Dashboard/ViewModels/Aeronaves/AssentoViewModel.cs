using SV.Application.InputModels.Aeronaves;
using SV.Application.InputModels.Voos;
using SV.Core.Entities.Aeronaves;
using System.Collections.Generic;

namespace SV.UI.Admin.Dashboard.ViewModels.Aeronaves
{
    public class AssentoViewModel
    {
        public AssentoInputModel AssentoInputModel { get; set; }
        public IEnumerable<Classe> Classes { get; set; }
    }
}
