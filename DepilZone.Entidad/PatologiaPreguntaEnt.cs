using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad
{
    public class PatologiaPreguntaEnt
    {
        public int Id { get; set; }
        public int IdPatologia { get; set; }
        public string Pregunta { get; set; }
        public int Orden { get; set; }
    }
}
