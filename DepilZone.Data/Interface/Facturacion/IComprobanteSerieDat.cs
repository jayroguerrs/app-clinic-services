using DepilZone.Entidad.DTO.Facturacion;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DepilZone.Data.Interface.Facturacion
{
	public interface IComprobanteSerieDat
	{
		Task<List<ComprobanteSerieDTO>> Listar(int idUsuario);
		Task<List<ComprobanteSerieDTO>> ListarBySedeTipoComprobante(int idUsuario, int idSede, int idTipoComprobante);
		Task<List<ComprobanteSerieDTO>> ListarByTipoComprobante(int idUsuario, int idTipoComprobante);
        Task<List<ComprobanteSerieDTO>> Listar2(int idUsuario);
        Task<ComprobanteSerieDTO> Buscar(int Id, int IdUsuario);
        Task<bool> Registrar(ComprobanteSerieDTO model);
		Task<bool> Modificar(int id, ComprobanteSerieDTO model);
		Task<bool> ActualizarNumero(int id, int numeroActual, int idUsuarioRegistro);
		Task<List<ComprobanteSerieDTO>> ListarToNotaCredito(int IdUsuario);
    }
}
