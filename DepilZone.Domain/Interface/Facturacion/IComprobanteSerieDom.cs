using DepilZone.Entidad.DTO.Facturacion;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface.Facturacion
{
	public interface IComprobanteSerieDom
	{
        Task<List<ComprobanteSerieDTO>> Listar(int IdUsuario);
        Task<List<ComprobanteSerieDTO>> ListarBySedeTipoComprobante(int IdUsuario, int IdSede, int IdTipoComprobante);
        Task<List<ComprobanteSerieDTO>> ListarByTipoComprobante(int IdUsuario, int IdTipoComprobante);
        Task<List<ComprobanteSerieDTO>> Listar2(int IdUsuario);
        Task<ComprobanteSerieDTO> Buscar(int Id, int IdUsuario);
        Task<bool> Registrar(ComprobanteSerieDTO model);
        Task<bool> Modificar(int id, ComprobanteSerieDTO model);
        Task<bool> ActualizarNumero(int id, int numeroActual, int idUsuarioRegistro);

        Task<List<ComprobanteSerieDTO>> ListarToNotaCredito(int IdUsuario);

    }
}
