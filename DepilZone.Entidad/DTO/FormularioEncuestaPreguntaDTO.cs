using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepilZone.Entidad.DTO
{
    public class FormularioEncuestaPreguntaDTO
    {
        public int Id { get; set; }
        public int IdFormularioEncuesta { get; set; }
        public string Texto { get; set; }
        public bool Multiple { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public DateTime? FechaModifico { get; set; }
        public int? IdUsuarioModifico { get; set; }
        public int Orden { get; set; }
        public int IdEstado { get; set; }
        public string TipoRespuesta { get; set; }
        public bool Obligatorio { get; set; }
        public List<FormularioEncuestaOpcionDTO> opciones { get; set; }

        public List<string> Respuestas { get; set; }
        public string Respuesta { get; set; }

    }
}
