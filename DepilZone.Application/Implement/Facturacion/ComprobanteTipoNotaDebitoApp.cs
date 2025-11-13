
using DepilZone.Application.Interface.Facturacion;
using DepilZone.Data.Interface.Facturacion;
using DepilZone.Entidad.DTO.Facturacion;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement.Facturacion
{
	public class ComprobanteTipoNotaDebitoApp : IComprobanteTipoNotaDebitoApp
	{
		private readonly IComprobanteTipoNotaDebitoDom _IComprobanteTipoNotaDebitoDom;
        public ComprobanteTipoNotaDebitoApp(IComprobanteTipoNotaDebitoDom IComprobanteTipoNotaDebitoDom)
        {
            this._IComprobanteTipoNotaDebitoDom = IComprobanteTipoNotaDebitoDom;
        }

        public async Task<List<ComprobanteTipoNotaDebitoDTO>> Listar(int IdUsuario)
        {
            return await _IComprobanteTipoNotaDebitoDom.Listar(IdUsuario);
        }

        public async Task<List<ComprobanteTipoNotaDebitoDTO>> Listar2(int IdUsuario)
        {
            return await _IComprobanteTipoNotaDebitoDom.Listar2(IdUsuario);
        }

        public async Task<ComprobanteTipoNotaDebitoDTO> Buscar(int Id, int IdUsuario)
        {
            return await _IComprobanteTipoNotaDebitoDom.Buscar(Id, IdUsuario);
        }

        public async Task<bool> Registrar(ComprobanteTipoNotaDebitoDTO model)
        {
            return await _IComprobanteTipoNotaDebitoDom.Registrar(model);
        }
        public async Task<bool> Modificar(int id, ComprobanteTipoNotaDebitoDTO model)
        {
            return await _IComprobanteTipoNotaDebitoDom.Modificar(id, model);
        }
        
    }
}
