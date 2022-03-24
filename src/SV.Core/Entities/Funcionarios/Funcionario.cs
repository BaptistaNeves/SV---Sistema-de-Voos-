using SV.Core.Entities.Base;
using System;

namespace SV.Core.Entities.Funcionarios
{
    public class Funcionario : Entidade
    {
        public Guid CategoriaFuncionarioId { get; private set; }
        public string Nome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Naturalidade { get; private set; }
        public string Nacionalidade { get; private set; }
        public string Documento { get; private set; }
        public string NumeroDocumento { get; private set; }
        public string NivelAcademico { get; private set; }
        public string AreaAcademica { get; private set; }
        public string Telefone { get; private set; }
        public string Email { get; private set; }
        public string Endereco { get; private set; }
        public string Sexo { get; private set; }
        public string EstadoCivil { get; private set; }
        public string Imagem { get; private set; }
        public bool Ativo { get; private set; }
        public string Observacao { get; private set; }

        public CategoriaFuncionario CategoriaFuncionario { get; private set; }
    }
}
