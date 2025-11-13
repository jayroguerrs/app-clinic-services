
using DepilZone.Data.Interface.Facturacion;
using DepilZone.Entidad.DTO.Facturacion;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class ComprobanteTipoNotaDebitoDom: IComprobanteTipoNotaDebitoDom
	{
		private readonly IComprobanteTipoNotaDebitoDat _IComprobanteTipoNotaDebitoDat;
		public ComprobanteTipoNotaDebitoDom(IComprobanteTipoNotaDebitoDat IComprobanteTipoNotaDebitoDat)
		{
			this._IComprobanteTipoNotaDebitoDat = IComprobanteTipoNotaDebitoDat;
		}
		public async Task<List<ComprobanteTipoNotaDebitoDTO>> Listar(int IdUsuario)
		{
			return await _IComprobanteTipoNotaDebitoDat.Listar(IdUsuario);
		}
        public async Task<List<ComprobanteTipoNotaDebitoDTO>> Listar2(int IdUsuario)
        {
            return await _IComprobanteTipoNotaDebitoDat.Listar2(IdUsuario);
        }
        public async Task<bool> Registrar(ComprobanteTipoNotaDebitoDTO model)
        {
            return await _IComprobanteTipoNotaDebitoDat.Registrar(model);
        }
        public async Task<bool> Modificar(int id, ComprobanteTipoNotaDebitoDTO model)
        {
            return await _IComprobanteTipoNotaDebitoDat.Modificar(id, model);
        }

        public async Task<ComprobanteTipoNotaDebitoDTO> Buscar(int Id, int IdUsuario)
        {
            return await _IComprobanteTipoNotaDebitoDat.Buscar(Id, IdUsuario);
        }

    }
}
