using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Entidad.DTO
{
    public class ClienteBusquedaCitasDTO
    {
    }

    public class ClienteResultDTO
    {
        public int IdCliente { get; set; }
        public string Cliente { get; set; }
        public string Nombre { get; set; }
    }

    public class VerTotalesDTO
    {
        public int IdEstado { get; set; }
        public string Estado { get; set; }
        public int Cantidad { get; set; }
    }

    public class ResponseCitasClienteDTO
    {
        public IList<CitasClienteDTO> Citas { get; set; }
        public int Total { get; set; }
        public string EsNuevoCliente { get; set; }
    }

    public class ResponseCitasClienteCcvoxDTO
    {
        public IList<CitasClienteDTO> Citas { get; set; }
        public string NombreCliente { get; set; }
        public int Id { get; set; }
    }

    public class CitasClienteDTO
    {
        public string FechaCita { get; set; }
        public int IdCita { get; set; }
        public int IdEstado { get; set; }
        public int IdTipoCita { get; set; }
        public int IdTipoCliente { get; set; }
        public int IdSede { get; set; }
        public decimal Total { get; set; }
        public string? ClienteNuevo { get; set; }
        public int IdServicio { get; set; }
        public int IdPreferente { get; set; }
        public float? PrecioDePagoFinal { get; set; }
        public string HoraInicio { get; set; }
        public string HoraTermino { get; set; }
        public int IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public IList<string> Zonas { get; set; }
        public bool Pagado { get; set; }
        public string Estado { get; set; }
        public int IdCronograma { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string NumerosCelulares { get; set; }
        public string SeudonimoPaciente { get; set; }
        public int? IdFichaAdmision { get; set; }
        public string? NuevoCliente { get; set; }
        public int IdTipoComprobante { get; set; }
        public int? IdTipoPago { get; set; }
        public string? ColorTipoPago { get; set; }
    }

    public class CitasBusquedaPorIdDTO : CitasClienteDTO
    {
        public string CelularCliente { get; set; }

    }

    public class ResponseCitasBusquedaPorIdDTO
    {
        public IList<CitasBusquedaPorIdDTO> Citas { get; set; }
        public int Total { get; set; }
        public string EsNuevoCliente { get; set; }
    }
}
