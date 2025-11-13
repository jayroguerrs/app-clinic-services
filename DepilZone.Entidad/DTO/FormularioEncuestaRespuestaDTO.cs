using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepilZone.Entidad.DTO
{
    public class FormularioEncuestaRespuestaDTO
    {
        public int Id { get; set; }
        public int IdFormulario { get; set; }
        public int IdCliente { get; set; }

        public int IdSede { get; set; }

        public int IdUsuarioRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }

        public DateTime? FechaModifico { get; set; }
        public int? IdUsuarioModifico { get; set; }
        public int IdEstado { get; set; }
        public List<RespuestasDTO> Respuestas { get; set; }


        public string UsuarioRegistro { get; set; }
        public string? UsuarioModifico { get; set; }
    }

    public class RespuestasDTO { 
        public int Id { get; set; }
        public int IdPregunta { get; set; }
        public int IdRespuesta { get; set; }

        public string? IdRespuestas { get; set; }

        public bool Adicional { get; set; }
        public string Tipo { get; set; }
        public string? RespuestaAdicional { get; set; }
        public string? RespuestaTexto { get; set; }
    }
}
