using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad.DTO
{
    public class CronogramaSeguimientoDTO
    {
        public int Id { get; set; }
        public int IdCronograma { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public int IdCronogramaSeguimientoConcepto { get; set; }
        public string Descripcion { get; set; }
        public string Detalle { get; set; }
        public DateTime FechaRegistro { get; set; }

        // secondary
        public string UsuarioRegistro { get; set; }

    }
}
