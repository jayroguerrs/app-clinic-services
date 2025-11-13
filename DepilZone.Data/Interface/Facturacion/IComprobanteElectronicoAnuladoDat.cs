using DepilZone.Entidad.DTO.Facturacion;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DepilZone.Data.Interface.Facturacion
{
	public interface IComprobanteElectronicoAnuladoDat
	{
        Task<ComprobanteElectronicoMotivoAnuladoDTO> BuscarPorComprobante(int IdVenta, int IdUsuario);
    }
}
