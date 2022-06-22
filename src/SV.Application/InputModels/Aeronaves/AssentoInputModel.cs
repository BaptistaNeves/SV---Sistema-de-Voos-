using System;
using System.ComponentModel.DataAnnotations;

namespace SV.Application.InputModels.Aeronaves
{
    public class AssentoInputModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Informe o número do assento!")]
        [Range(1, int.MaxValue,  ErrorMessage = "O número do assento deve ser maior que zero!")]
        public int Numero { get; set; }

        public Guid VooId { get; set; }

        [Required(ErrorMessage = "Informe a classe deste assento!")]
        public Guid ClasseId { get; set; }
    }
}
