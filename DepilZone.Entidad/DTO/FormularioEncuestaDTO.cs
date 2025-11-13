using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepilZone.Entidad.DTO
{
    public class FormularioEncuestaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public DateTime? FechaModifico { get; set; }
        public int? IdUsuarioModifico { get; set; }
        public int IdEstado { get; set; }
        public List<FormularioEncuestaPreguntaDTO> preguntas { get; set; }

        public bool Realizado { get; set; }

        
        public string? Contenido { get; set; }

        public string UsuarioRegistro { get; set; }
        public string? UsuarioModifico { get; set; }
    }
}
