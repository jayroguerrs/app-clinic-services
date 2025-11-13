
using DepilZone.Application.Interface.Facturacion;
using DepilZone.Data.Interface.Facturacion;
using DepilZone.Entidad.DTO.Facturacion;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement.Facturacion
{
	public class ComprobanteUnidadMedidaApp : IComprobanteUnidadMedidaApp
	{
		private readonly IComprobanteUnidadMedidaDom _IComprobanteUnidadMedidaDom;
        public ComprobanteUnidadMedidaApp(IComprobanteUnidadMedidaDom IComprobanteUnidadMedidaDom)
        {
            this._IComprobanteUnidadMedidaDom = IComprobanteUnidadMedidaDom;
        }

        public async Task<List<ComprobanteUnidadMedidaDTO>> Listar(int IdUsuario)
        {
            return await _IComprobanteUnidadMedidaDom.Listar(IdUsuario);
        }

        public async Task<List<ComprobanteUnidadMedidaDTO>> Listar2(int IdUsuario)
        {
            return await _IComprobanteUnidadMedidaDom.Listar2(IdUsuario);
        }

        public async Task<ComprobanteUnidadMedidaDTO> Buscar(int Id, int IdUsuario)
        {
            return await _IComprobanteUnidadMedidaDom.Buscar(Id, IdUsuario);
        }

        public async Task<bool> Registrar(ComprobanteUnidadMedidaDTO model)
        {
            return await _IComprobanteUnidadMedidaDom.Registrar(model);
        }
        public async Task<bool> Modificar(int id, ComprobanteUnidadMedidaDTO model)
        {
            return await _IComprobanteUnidadMedidaDom.Modificar(id, model);
        }
        
    }
}
