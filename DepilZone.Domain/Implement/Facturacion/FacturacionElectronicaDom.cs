
using DepilZone.Data.Interface.Facturacion;
using DepilZone.Entidad.DTO.Facturacion;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class FacturacionElectronicaDom: IFacturacionElectronicaDom
	{
		private readonly IFacturacionElectronicaDat _IFacturacionElectronicaDat;
		public FacturacionElectronicaDom(IFacturacionElectronicaDat IFacturacionElectronicaDat)
		{
			this._IFacturacionElectronicaDat = IFacturacionElectronicaDat;
		}
		public async Task<CitaDatosComprobanteDTO> ObtenerDatosComprobanteCita(int IdCita, int IdUsuario)
        {
			return await _IFacturacionElectronicaDat.ObtenerDatosComprobanteCita(IdCita, IdUsuario);
		}

        public async Task<List<CitaDetalleDatosComprobanteDTO>> ObtenerCitaDetalleComprobanteCita(int IdCita, int IdUsuario)
        {
            return await _IFacturacionElectronicaDat.ObtenerCitaDetalleComprobanteCita(IdCita, IdUsuario);
        }

    }
}
