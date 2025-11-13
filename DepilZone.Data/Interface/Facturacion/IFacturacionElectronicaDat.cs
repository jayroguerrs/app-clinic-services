using DepilZone.Entidad.DTO.Facturacion;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DepilZone.Data.Interface.Facturacion
{
	public interface IFacturacionElectronicaDat
	{
        Task<CitaDatosComprobanteDTO> ObtenerDatosComprobanteCita(int IdCita, int IdUsuario);

        Task<List<CitaDetalleDatosComprobanteDTO>> ObtenerCitaDetalleComprobanteCita(int IdCita, int IdUsuario);

    }
}
