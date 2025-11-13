using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad
{
    public class PatologiaEnt
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public IList<PatologiaPreguntaEnt> PatologiaPregunta { get; set; }
    }
}
