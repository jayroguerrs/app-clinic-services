using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad.DTO
{
    public class CitaSeguimientoDTO
    {
        public int Id { get; set; }
        public int IdCita { get; set; }
        public string IdCitaText
        {
            get
            {
                return "CI-" + IdCita.ToString("000000");
            }
        }
        public int IdUsuario { get; set; }
        public int IdCitaSeguimientoConcepto { get; set; }
        public string Descripcion { get; set; }
        public string Usuario { get; set; }
        public string Detalle { get; set; }
        public DateTime FechaSeguimiento { get; set; }
        public string FechaSeguimientoTexto
        {
            get 
            {
                return FechaSeguimiento.ToString("dd-MM-yyyy HH:mm");
            }
        }

    }
}
