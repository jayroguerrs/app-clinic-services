
using DepilZone.Data.Interface.Facturacion;
using DepilZone.Entidad.DTO.Facturacion;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class ComprobanteSerieDom: IComprobanteSerieDom
	{
		private readonly IComprobanteSerieDat _IComprobanteSerieDat;
		public ComprobanteSerieDom(IComprobanteSerieDat IComprobanteSerieDat)
		{
			this._IComprobanteSerieDat = IComprobanteSerieDat;
		}
		public async Task<List<ComprobanteSerieDTO>> ListarBySedeTipoComprobante(int IdUsuario, int IdSede, int IdTipoComprobante)
		{
			return await _IComprobanteSerieDat.ListarBySedeTipoComprobante( IdUsuario,  IdSede,  IdTipoComprobante);
		}
        public async Task<List<ComprobanteSerieDTO>> ListarByTipoComprobante(int IdUsuario, int IdTipoComprobante)
        {
            return await _IComprobanteSerieDat.ListarByTipoComprobante(IdUsuario, IdTipoComprobante);
        }
        public async Task<List<ComprobanteSerieDTO>> Listar(int IdUsuario)
        {
            return await _IComprobanteSerieDat.Listar(IdUsuario);
        }
        public async Task<List<ComprobanteSerieDTO>> Listar2(int IdUsuario)
        {
            return await _IComprobanteSerieDat.Listar2(IdUsuario);
        }
        public async Task<bool> Registrar(ComprobanteSerieDTO model)
        {
            return await _IComprobanteSerieDat.Registrar(model);
        }
        public async Task<bool> Modificar(int id, ComprobanteSerieDTO model)
        {
            return await _IComprobanteSerieDat.Modificar(id, model);
        }

        public async Task<ComprobanteSerieDTO> Buscar(int Id, int IdUsuario)
        {
            return await _IComprobanteSerieDat.Buscar(Id, IdUsuario);
        }

       
        public async Task<bool> ActualizarNumero(int id, int numeroActual, int idUsuarioRegistro)
        {
            return await _IComprobanteSerieDat.ActualizarNumero(id, numeroActual, idUsuarioRegistro);
        }


        public async Task<List<ComprobanteSerieDTO>> ListarToNotaCredito(int IdUsuario)
        {
            return await _IComprobanteSerieDat.ListarToNotaCredito(IdUsuario);
        }

    }
}
