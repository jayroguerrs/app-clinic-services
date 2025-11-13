
using DepilZone.Application.Interface.Facturacion;
using DepilZone.Data.Interface.Facturacion;
using DepilZone.Entidad.DTO.Facturacion;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement.Facturacion
{
	public class ComprobanteSerieApp : IComprobanteSerieApp
	{
		private readonly IComprobanteSerieDom _IComprobanteSerieDom;
        public ComprobanteSerieApp(IComprobanteSerieDom IComprobanteSerieDom)
        {
            this._IComprobanteSerieDom = IComprobanteSerieDom;
        }

        public async Task<List<ComprobanteSerieDTO>> Listar(int IdUsuario)
        {
            return await _IComprobanteSerieDom.Listar(IdUsuario);
        }
        public async Task<List<ComprobanteSerieDTO>> ListarBySedeTipoComprobante(int IdUsuario, int idSede, int idTipoComprobante)
        {
            return await _IComprobanteSerieDom.ListarBySedeTipoComprobante(IdUsuario, idSede, idTipoComprobante);
        }

        public async Task<List<ComprobanteSerieDTO>> ListarByTipoComprobante(int IdUsuario,int idTipoComprobante)
        {
            return await _IComprobanteSerieDom.ListarByTipoComprobante(IdUsuario,idTipoComprobante);
        }

        public async Task<List<ComprobanteSerieDTO>> Listar2(int IdUsuario)
        {
            return await _IComprobanteSerieDom.Listar2(IdUsuario);
        }

        public async Task<ComprobanteSerieDTO> Buscar(int Id, int IdUsuario)
        {
            return await _IComprobanteSerieDom.Buscar(Id, IdUsuario);
        }

        public async Task<bool> Registrar(ComprobanteSerieDTO model)
        {
            return await _IComprobanteSerieDom.Registrar(model);
        }
        public async Task<bool> Modificar(int id, ComprobanteSerieDTO model)
        {
            return await _IComprobanteSerieDom.Modificar(id, model);
        }

        public async Task<bool> ActualizarNumero(int id, int numeroActual, int idUsuarioRegistro)
        {
            return await _IComprobanteSerieDom.ActualizarNumero(id, numeroActual, idUsuarioRegistro);
        }

        public async Task<List<ComprobanteSerieDTO>> ListarToNotaCredito(int IdUsuario)
        {
            return await _IComprobanteSerieDom.ListarToNotaCredito(IdUsuario);
        }


    }
}
