using System;
using System.ComponentModel.DataAnnotations;

namespace SV.Application.InputModels.Funcionarios
{
    public class CategoriaFuncionarioInputModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Informe o Nome da categoria!")]
        [MinLength(2, ErrorMessage = "O Nome de ter no minímo 2 caracteres!")]
        public string Nome { get; set; }

        public string Descricao { get; set; }
    }
}
