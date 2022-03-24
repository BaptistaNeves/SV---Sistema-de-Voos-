using System;
using System.ComponentModel.DataAnnotations;

namespace SV.Application.InputModels.Aeronaves
{
    public class ClasseInputModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Informe o Nome/Descrição da Classe!")]
        public string Descricao { get; set; }
    }
}
