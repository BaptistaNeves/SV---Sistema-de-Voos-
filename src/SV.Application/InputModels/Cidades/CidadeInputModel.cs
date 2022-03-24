using System;
using System.ComponentModel.DataAnnotations;

namespace SV.Application.InputModels.Cidades
{
    public class CidadeInputModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Informe o nome da Cidade!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o País desta Cidade!")]
        public string Pais { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
    }
}
