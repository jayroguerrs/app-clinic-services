
using DepilZone.Application.Interface.Facturacion;
using DepilZone.Data.Interface.Facturacion;
using DepilZone.Entidad.DTO.Facturacion;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement.Facturacion
{
	public class ComprobanteTipoNotaCreditoApp : IComprobanteTipoNotaCreditoApp
	{
		private readonly IComprobanteTipoNotaCreditoDom _IComprobanteTipoNotaCreditoDom;
        public ComprobanteTipoNotaCreditoApp(IComprobanteTipoNotaCreditoDom IComprobanteTipoNotaCreditoDom)
        {
            this._IComprobanteTipoNotaCreditoDom = IComprobanteTipoNotaCreditoDom;
        }

        public async Task<List<ComprobanteTipoNotaCreditoDTO>> Listar(int IdUsuario)
        {
            return await _IComprobanteTipoNotaCreditoDom.Listar(IdUsuario);
        }

        public async Task<List<ComprobanteTipoNotaCreditoDTO>> Listar2(int IdUsuario)
        {
            return await _IComprobanteTipoNotaCreditoDom.Listar2(IdUsuario);
        }

        public async Task<ComprobanteTipoNotaCreditoDTO> Buscar(int Id, int IdUsuario)
        {
            return await _IComprobanteTipoNotaCreditoDom.Buscar(Id, IdUsuario);
        }

        public async Task<bool> Registrar(ComprobanteTipoNotaCreditoDTO model)
        {
            return await _IComprobanteTipoNotaCreditoDom.Registrar(model);
        }
        public async Task<bool> Modificar(int id, ComprobanteTipoNotaCreditoDTO model)
        {
            return await _IComprobanteTipoNotaCreditoDom.Modificar(id, model);
        }
        
    }
}
