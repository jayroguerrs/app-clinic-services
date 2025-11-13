using DepilZone.Entidad.DTO.C360;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DepilZone.Entidad.DTO
{
    public class CronogramaCitaDTO
    {
        public int Id { get; set; }
        //public string Uuid { get; set; }
        public int IdCliente { get; set; }
        public int IdSede { get; set; }
        public int IdTipoCliente { get; set; }
        public int IdServicio { get; set; }
        public int IdTratamiento { get; set; }
        public int IdZona { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public int? IdUsuarioModifico { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaModifico { get; set; }
        //public List<CronogramaCitaSemanaDTO> Semanas { get; set; }
        public decimal Precio { get; set; }
        public int IdPreferente { get; set; }

        // secondary
        public string UsuarioRegistro { get; set; }
        #nullable enable
        public string? UsuarioModifico { get; set; }
#nullable enable
        public string? Servicio { get; set; }
#nullable enable
        public string? ServicioNombreCorto { get; set; }
#nullable enable
        public string? ServicioColor { get; set; }
#nullable enable
        public string? Sede { get; set; }
#nullable enable
        public string? Zona { get; set; }
        public int NumeroCitas { get; set; }
        public string? Tratamiento { get; set; }

    }

    /*public class CronogramaCitaSemanaDTO
    {
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }

    }*/


    public class CronogramaCita_CitaDTO
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int IdEstado { get; set; }
        public int IdTipoCita { get; set; }
        public string Estado { get; set; }
        public string EstadoColor { get; set; }
        public List<Cita360DetallesDTO> Detalles { get; set; }
        public int IdPreferente { get; set; }

    }

}
