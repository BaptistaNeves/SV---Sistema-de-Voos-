using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace SV.Application.InputModels.Funcionarios
{
    public class FuncionarioInputModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Informe a Categoria deste Funcionário!")]
        [Display(Name = "Categoria")]
        public Guid CategoriaFuncionarioId { get; set; }

        [Required(ErrorMessage = "O Nome do funcionário deve ser informado!")]
        [MinLength(2, ErrorMessage = "O Nome deve ter no Minimo 2 caracteres!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A Data de Nascimento do funcionário deve ser informada!")]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "A Naturalidade do funcionario deve ser informada!")]
        public string Naturalidade { get; set; }

        [Required(ErrorMessage = "A Nacionalidade do funcioanário deve ser informada!")]
        public string Nacionalidade { get; set; }

        [Required(ErrorMessage = "Informe o Tipo de Documento!")]
        public string Documento { get; set; }

        [Required(ErrorMessage = "O Número do Documento deve ser informado!")]
        public string NumeroDocumento { get; set; }

        public string NivelAcademico { get; set; }
        public string AreaAcademica { get; set; }

        [Required(ErrorMessage = "O Telefone do funcionário deve ser informado!")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O Email do funcionário deve ser informado!")]
        [EmailAddress(ErrorMessage = "O Email informado não é válido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O Endereço do funcionário deve ser informado!")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "O Sexo do funcionário deve ser informado!")]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "O Estado Civil do funcionário deve ser informado!")]
        [Display(Name = "Estado Civil")]
        public string EstadoCivil { get; set; }

        public string Imagem { get; set; }

        [Required(ErrorMessage = "Seleccione uma foto para o funcionário!")]
        public IFormFile ImagemUpload { get; set; }

        public bool Ativo { get; set; }
        public string Observacao { get; set; }
    }
}
