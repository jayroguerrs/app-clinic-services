using DepilZone.Entidad.DTO.Facturacion;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;


namespace DepilZone.Data.Interface.Facturacion
{
	public interface IComprobanteAnulacionDat
	{
        Task<List<ComprobanteElectronicoAnulacionDTO>> Obtener(DateTime fechaDesde, DateTime fechaHasta, int idTipoComprobante, int idSede, int idUsuario);
    }
}
