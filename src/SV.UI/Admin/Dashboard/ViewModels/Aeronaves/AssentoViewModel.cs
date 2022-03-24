using Microsoft.AspNetCore.Mvc.Rendering;
using SV.Application.InputModels.Aeronaves;
using SV.Core.Entities.Aeronaves;
using SV.Core.ViewModels.Utility;
using System.Collections.Generic;

namespace SV.UI.Admin.Dashboard.ViewModels.Aeronaves
{
    public class AssentoViewModel
    {
        public AssentoInputModel AssentoModel { get; set; }
        public IEnumerable<Classe> Classes { get; set; }
        public IEnumerable<Aeronave> Aeronaves { get; set; }
    }
}
