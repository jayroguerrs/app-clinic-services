
using DepilZone.Application.Interface.Facturacion;
using DepilZone.Data.Interface.Facturacion;
using DepilZone.Entidad.DTO.Facturacion;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement.Facturacion
{
	public class ComprobanteAnulacionApp : IComprobanteAnulacionApp
	{

		private readonly IComprobanteAnulacionDom _IComprobanteAnulacionDom;
        public ComprobanteAnulacionApp(IComprobanteAnulacionDom IComprobanteAnulacionDom)
        {
            this._IComprobanteAnulacionDom = IComprobanteAnulacionDom;
        }

        public async Task<List<ComprobanteElectronicoAnulacionDTO>> Obtener(DateTime fechaDesde, DateTime fechaHasta, int idTipoComprobante, int idSede, int idUsuario)
        {
            return await _IComprobanteAnulacionDom.Obtener( fechaDesde,  fechaHasta,  idTipoComprobante,  idSede,  idUsuario);
        }

    }
}
