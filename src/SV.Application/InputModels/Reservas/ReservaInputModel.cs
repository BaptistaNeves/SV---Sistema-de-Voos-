using System;
using System.ComponentModel.DataAnnotations;

namespace SV.Application.InputModels.Reservas
{
    public class ReservaInputModel
    {
        [Key]
        public Guid Id { get; set; }

        public Guid VooId { get; set; }

        [Required(ErrorMessage = "O assento desejado deve ser informado!")]
        public Guid AssentoId { get; set; }

        public double Preco { get; set; }

        [Required(ErrorMessage = "O nome do passageiro deve ser informado!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O tipo de documento deve ser informado!")]
        public string TipoDocumento { get; set; }

        [Required(ErrorMessage = "O número do documento deve ser informado!")]
        public string NumeroDocumento { get; set; }

        [Required(ErrorMessage = "O e-mail deve ser informado!")]
        [EmailAddress(ErrorMessage = "Endereço de e-mail inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O telefone de ser informado!")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O endereço deve ser informado!")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Selecione o sexo!")]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "a data de nascimento deve ser informada!")]
        public DateTime DataNascimento { get; set; }
    }
}
