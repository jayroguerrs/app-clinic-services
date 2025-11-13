
using DepilZone.Entidad.DTO.Facturacion;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;


namespace DepilZone.Application.Interface.Facturacion
{
    public interface IComprobanteAnulacionApp
	{
        Task<List<ComprobanteElectronicoAnulacionDTO>> Obtener(DateTime fechaDesde, DateTime fechaHasta, int idTipoComprobante, int idSede, int idUsuario);
    }
}
