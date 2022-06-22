using SV.Application.InputModels.Reservas;
using SV.Core.DTOs.Voos;
using SV.Core.Entities.Aeronaves;
using System.Collections.Generic;

namespace SV.UI.ViewModels
{
    public class ReservaViewModel
    {
        public IEnumerable<Assento> Executiva { get; set; }
        public IEnumerable<Assento> Economica { get; set; }
        public VooDto Voo { get; set; }
        public ReservaInputModel ReservaInputModel { get; set; }
    }
}
