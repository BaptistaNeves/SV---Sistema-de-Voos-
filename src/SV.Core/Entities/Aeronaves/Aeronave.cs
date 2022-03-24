using SV.Core.Entities.Base;
using System.Collections.Generic;

namespace SV.Core.Entities.Aeronaves
{
    public class Aeronave : Entidade
    {
        public string Modelo { get; private set; }
        public string Fabricante { get; private set; }
        public int TotalDeAssentos { get; private set; }
        public bool Activo { get; private set; }

        public ICollection<Assento> Assentos { get; private set; }

        public Aeronave(string modelo, string fabricante, int totalDeAssentos, bool activo)
        {
            Modelo = modelo;
            Fabricante = fabricante;
            TotalDeAssentos = totalDeAssentos;
            Activo = activo;
        }
    }
}
