using System;
using System.ComponentModel.DataAnnotations;

namespace SV.Application.InputModels.Voos
{
    public class VooInputModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Seleccione o tipo de voo!")]
        [Display(Name = "Tipo de Voo")]
        public Guid TipoDeVooId { get; set; }

        [Required(ErrorMessage = "Seleccione a aeronave deste voo!")]
        [Display(Name = "Aeoronave")]
        public Guid AeronaveId { get; set; }

        [Required(ErrorMessage = "Seleccione o aeroporto de origem deste voo!")]
        [Display(Name = "Aeroporto de origem")]
        public string AeroportoDeOrigem { get; set; }

        [Required(ErrorMessage = "Seleccione o aeroporto de destini deste voo!")]
        [Display(Name = "Aeroporto de destino")]
        public string AeroportoDestino { get; set; }

        [Required(ErrorMessage = "Informe uma Descrição/Nome para este voo!")]
        [MinLength(5, ErrorMessage = "A descrição deve ter no minimo 5 caracteres!")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Informe a data de partida deste voo!")]
        [DataType(DataType.Date)]
        [Display(Name = "Data de partida")]
        public DateTime DataDePartida { get; set; }

        [Required(ErrorMessage = "Informe a hora de partida deste voo!")]
        [DataType(DataType.Time)]
        [Display(Name = "Hora de partida")]
        public DateTime HoraDePartida { get; set; }

        [Required(ErrorMessage = "Informe a previsão de chegada deste voo!")]
        [DataType(DataType.Date)]
        [Display(Name = "Previsão de chegada")]
        public DateTime PrevisaoDeChegada { get; set; }

        [Required(ErrorMessage = "Informe a previsão de chegada ao destino final deste voo!")]
        [DataType(DataType.Date, ErrorMessage = "O formato de data não é válido!")]
        [Display(Name = "Data de partida")]
        public DateTime PrevisaoDeChegadaAoDestino { get; set; }

        public bool Estado { get; set; }
    }
}
