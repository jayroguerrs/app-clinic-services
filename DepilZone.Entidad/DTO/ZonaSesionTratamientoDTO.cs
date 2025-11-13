using System;
using System.Collections.Generic;

namespace DepilZone.Entidad.DTO
{
    public class ZonaSesionTratamientoDTO
    {
        public int Id { get; set; }
        public int IdZona { get; set; }
        public int Sesion { get; set; }
        public List<int> IdTratamientos { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public int? IdUsuarioModifico { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaModifico { get; set; }

        // secondary
        public string UsuarioRegistro { get; set; }

    }


    public class ZonaSesionTratamientosDTO
    {
        public int IdUsuarioRegistro { get; set; }
        public int IdZona { get; set; }
        public List<ZonaSesionTratamientoDTO> Tratamientos {get;set;}
    }   

}
