
using DepilZone.Data.Interface.Facturacion;
using DepilZone.Entidad.DTO.Facturacion;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class ComprobanteTipoNotaCreditoDom: IComprobanteTipoNotaCreditoDom
	{
		private readonly IComprobanteTipoNotaCreditoDat _IComprobanteTipoNotaCreditoDat;
		public ComprobanteTipoNotaCreditoDom(IComprobanteTipoNotaCreditoDat IComprobanteTipoNotaCreditoDat)
		{
			this._IComprobanteTipoNotaCreditoDat = IComprobanteTipoNotaCreditoDat;
		}
		public async Task<List<ComprobanteTipoNotaCreditoDTO>> Listar(int IdUsuario)
		{
			return await _IComprobanteTipoNotaCreditoDat.Listar(IdUsuario);
		}
        public async Task<List<ComprobanteTipoNotaCreditoDTO>> Listar2(int IdUsuario)
        {
            return await _IComprobanteTipoNotaCreditoDat.Listar2(IdUsuario);
        }
        public async Task<bool> Registrar(ComprobanteTipoNotaCreditoDTO model)
        {
            return await _IComprobanteTipoNotaCreditoDat.Registrar(model);
        }
        public async Task<bool> Modificar(int id, ComprobanteTipoNotaCreditoDTO model)
        {
            return await _IComprobanteTipoNotaCreditoDat.Modificar(id, model);
        }

        public async Task<ComprobanteTipoNotaCreditoDTO> Buscar(int Id, int IdUsuario)
        {
            return await _IComprobanteTipoNotaCreditoDat.Buscar(Id, IdUsuario);
        }

    }
}
