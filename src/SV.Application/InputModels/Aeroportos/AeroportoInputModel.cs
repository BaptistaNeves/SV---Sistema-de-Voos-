using System;
using System.ComponentModel.DataAnnotations;

namespace SV.Application.InputModels.Aeroportos
{
    public class AeroportoInputModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Informe o Nome do Aeroporto!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe a Cidade do Aeroporto!")]
        [Display(Name = "Cidade")]
        public Guid CidadeId { get; set; }

        public bool Activo { get; set; }
    }
}
