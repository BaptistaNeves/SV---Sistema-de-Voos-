using System;

namespace SV.Core.DTOs.Voos
{
    public class VooDto
    {
        public Guid Id { get; set; }
        public string TipoDeVoo { get; set; }
        public string Aeronave { get; set; }
        public string AeroportoDeOrigem { get; set; }
        public string AeroportoDestino { get; set; }
        public string Descricao { get; set; }
        public string Piloto { get; set; }
        public string CoPiloto { get; set; }
        public string Imagem { get; set; }
        public double PrecoCusto { get; set; }
        public string DataIda { get; set; }
        public string DataRegresso { get; set; }
        public DateTime DataDePartida { get; set; }
        public DateTime HoraDePartida { get; set; }
        public DateTime PrevisaoDeChegada { get; set; }
        public DateTime PrevisaoDeChegadaAoDestino { get; set; }

        public bool Estado { get; set; }
    }
}
