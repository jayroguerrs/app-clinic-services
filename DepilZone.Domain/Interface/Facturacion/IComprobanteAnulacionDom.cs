using DepilZone.Entidad.DTO.Facturacion;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface.Facturacion
{
	public interface IComprobanteAnulacionDom
	{
        Task<List<ComprobanteElectronicoAnulacionDTO>> Obtener(DateTime fechaDesde, DateTime fechaHasta, int idTipoComprobante, int idSede, int idUsuario);
    }
}
