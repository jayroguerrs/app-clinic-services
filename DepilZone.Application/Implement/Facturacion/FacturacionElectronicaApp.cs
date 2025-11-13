
using DepilZone.Application.Interface.Facturacion;
using DepilZone.Data.Interface.Facturacion;
using DepilZone.Entidad.DTO.Facturacion;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement.Facturacion
{
	public class FacturacionElectronicaApp : IFacturacionElectronicaApp
	{
		private readonly IFacturacionElectronicaDom _IFacturacionElectronicaDom;
        public FacturacionElectronicaApp(IFacturacionElectronicaDom IFacturacionElectronicaDom)
        {
            this._IFacturacionElectronicaDom = IFacturacionElectronicaDom;
        }

        public async Task<CitaDatosComprobanteDTO> ObtenerDatosComprobanteCita(int IdCita, int IdUsuario)
        {
            return await _IFacturacionElectronicaDom.ObtenerDatosComprobanteCita(IdCita, IdUsuario);
        }

        public async Task<List<CitaDetalleDatosComprobanteDTO>> ObtenerCitaDetalleComprobanteCita(int IdCita, int IdUsuario)
        {
            return await _IFacturacionElectronicaDom.ObtenerCitaDetalleComprobanteCita(IdCita, IdUsuario);
        }


    }
}
