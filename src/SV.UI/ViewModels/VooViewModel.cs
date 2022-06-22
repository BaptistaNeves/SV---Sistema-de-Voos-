using SV.Core.DTOs.Voos;
using SV.Core.Entities.Aeronaves;
using System.Collections.Generic;

namespace SV.UI.ViewModels
{
    public class VooViewModel
    {
        public IEnumerable<Classe> Executiva { get; set; }
        public IEnumerable<Classe> Economica { get; set; }
        public VooDto Voo { get; set; }
    }
}
