﻿using SV.Core.Entities.Aeronaves;
using SV.Core.Entities.Aeroportos;
using SV.Core.Entities.Base;
using SV.Core.Entities.Reservas;
using System;
using System.Collections.Generic;

namespace SV.Core.Entities.Voos
{
    public class Voo : Entidade
    {
        public Guid TipoDeVooId { get; private set; }
        public Guid AeronaveId { get; private set; }
        public string AeroportoDeOrigem { get; private set; }
        public string AeroportoDestino { get; private set; }
        public double PrecoCusto { get; set; }
        public string Descricao { get; private set; }
        public string Piloto { get; private set; }
        public string CoPiloto { get; private set; }
        public string Imagem { get; private set; }

        public DateTime DataDePartida { get; private set; }
        public DateTime HoraDePartida { get; private set; }
        public DateTime PrevisaoDeChegada { get; private set; }
        public DateTime PrevisaoDeChegadaAoDestino { get; private set; }

        public bool Estado { get; private set; }

        public TipoDeVoo TipoDeVoo { get; private set; }
        public Aeroporto Aeroporto { get; private set; }
        public Aeronave Aeronave { get; private set; }
        public ICollection<Assento> Assentos { get; set; }
        public ICollection<Reserva> Reservas { get; set; }
        

        public Voo(Guid tipoDeVooId, Guid aeronaveId, string aeroportoDeOrigem, 
                   string aeroportoDestino, string descricao, DateTime dataDePartida, 
                   DateTime horaDePartida, DateTime previsaoDeChegada, 
                   DateTime previsaoDeChegadaAoDestino, bool estado)
        {
            TipoDeVooId = tipoDeVooId;
            AeronaveId = aeronaveId;
            AeroportoDeOrigem = aeroportoDeOrigem;
            AeroportoDestino = aeroportoDestino;
            Descricao = descricao;
            DataDePartida = dataDePartida;
            HoraDePartida = horaDePartida;
            PrevisaoDeChegada = previsaoDeChegada;
            PrevisaoDeChegadaAoDestino = previsaoDeChegadaAoDestino;
            Estado = estado;
        }
    }
}
