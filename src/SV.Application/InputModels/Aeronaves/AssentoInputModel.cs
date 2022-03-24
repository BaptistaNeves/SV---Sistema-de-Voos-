using System;
using System.ComponentModel.DataAnnotations;

namespace SV.Application.InputModels.Aeronaves
{
    public class AssentoInputModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Informe o Número do Assento!")]
        [Range(1, int.MaxValue,  ErrorMessage = "O Número do Assento deve ser maior que zero!")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "Informe a Aeronave deste Assento!")]
        public Guid AeronaveId { get; set; }

        [Required(ErrorMessage = "Informe a Classe deste Assento!")]
        public Guid ClasseId { get; set; }
    }
}
