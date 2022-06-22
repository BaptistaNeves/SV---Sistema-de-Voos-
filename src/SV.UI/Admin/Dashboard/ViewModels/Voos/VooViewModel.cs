using SV.Application.InputModels.Aeronaves;
using SV.Application.InputModels.Voos;
using SV.Core.DTOs.Funcionarios;
using SV.Core.Entities.Aeronaves;
using SV.Core.Entities.Aeroportos;
using SV.Core.Entities.Voos;
using System.Collections.Generic;

namespace SV.UI.Admin.Dashboard.ViewModels.Voos
{
    public class VooViewModel
    {
        public VooInputModel VooInputModel { get; set; }
        public AssentoInputModel AssentoInputModel { get; set; }
        public IEnumerable<Aeroporto> Aeroportos { get; set; }
        public IEnumerable<Classe> Classes { get; set; }
        public IEnumerable<Assento> Assentos { get; set; }
        public IEnumerable<Aeronave> Aeronaves { get; set; }
        public IEnumerable<TipoDeVoo> TiposDeVoo { get; set; }
        public IEnumerable<FuncionarioPilotoECopilotoDto> Pilotos { get; set; }
        public IEnumerable<FuncionarioPilotoECopilotoDto> CoPilotos { get; set; }
    }
}
