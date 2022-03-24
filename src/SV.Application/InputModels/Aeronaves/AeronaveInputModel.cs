using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SV.Application.InputModels.Aeronaves
{
    public class AeronaveInputModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Informe o Modelo da Aeronave!")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "Informe o Fabricante da Aeronave!")]
        public string Fabricante { get; set; }

        [Required(ErrorMessage = "Informe o Número total de assentos desta Aeronave!")]
        [Range(1,int.MaxValue, ErrorMessage = "O Número de total de assentos deve ser maior que zero!")]
        public int TotalDeAssentos { get; set; }

        public bool Activo { get; set; }
    }
}
