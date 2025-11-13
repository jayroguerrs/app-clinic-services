
using DepilZone.Data.Interface.Facturacion;
using DepilZone.Entidad.DTO.Facturacion;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class ComprobanteAnulacionDom: IComprobanteAnulacionDom
	{
		private readonly IComprobanteAnulacionDat _IComprobanteAnulacionDat;
		public ComprobanteAnulacionDom(IComprobanteAnulacionDat IComprobanteAnulacionDat)
		{
			this._IComprobanteAnulacionDat = IComprobanteAnulacionDat;
		}
        public async Task<List<ComprobanteElectronicoAnulacionDTO>> Obtener(DateTime fechaDesde, DateTime fechaHasta, int idTipoComprobante, int idSede, int idUsuario)
		{
			return await _IComprobanteAnulacionDat.Obtener(fechaDesde, fechaHasta, idTipoComprobante, idSede, idUsuario);
        }
      

    }
}
