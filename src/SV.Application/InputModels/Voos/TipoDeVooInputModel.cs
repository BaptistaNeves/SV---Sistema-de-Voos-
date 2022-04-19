using System;
using System.ComponentModel.DataAnnotations;

namespace SV.Application.InputModels.Voos
{
    public class TipoDeVooInputModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O nome do tipo de voo deve ser informado!")]
        [MinLength(5, ErrorMessage = "O nome deve ter no minimo 5 caracteres!")]
        public string Nome { get; set; }

        public string Descricao { get; set; }
    }
}
