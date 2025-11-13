using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad.DTO
{
    public class HistoriaClinicaDetalleGridDTO
    {
        public int Id { get; set; }
        public int IdHistoriaClinica { get; set; }
        public DateTime FechaDetalle { get; set; }
        public int IdCita { get; set; }
        public int IdZonaTratamiento { get; set; }
        public string ZonaTratamiento { get; set; }
        public string Fluencia { get; set; }
        public string ValorKJ { get; set; }
        public int NumSesion { get; set; }
        public string Comentario { get; set; }


    }
}
