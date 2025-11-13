using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad.DTO
{
    public class VentaTicketDTO
    {
        public int Id { get; set; }
        public int IdCita { get; set; }
        public string Ticket { get; set; }
        public int IdEstado { get; set; }
        public DateTime FechaRegistra { get; set; }
        public DateTime? FechaModifica { get; set; }
        public string? UsuarioModifica { get; set; }
        public string FechaTicket
        {
            get
            {
                return FechaRegistra.ToString("dd-MM-yyyy");
            }
        }
        public string HoraTicket {
            get
            {
                return FechaRegistra.ToString("HH:mm:ss");
            }
        }
        public string NumeroCita
        {
            get { return "CI-" + IdCita.ToString("000000"); }
        }
        public string Cliente { get; set; }
        public decimal PTotal { get; set; }
        public string Concepto { get; set; }
        public string Sede { get; set; }
        public string Zonas { get; set; }
    }
}
