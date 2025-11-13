using DepilZone.Entidad.DTO.Facturacion;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DepilZone.Data.Interface.Facturacion
{
	public interface IFacturaTipoDocumentoDat
	{
		Task<List<FacturaTipoDocumentoDTO>> Listar(int idUsuario);
		Task<List<FacturaTipoDocumentoDTO>> Listar2(int idUsuario);
        Task<FacturaTipoDocumentoDTO> Buscar(int Id, int IdUsuario);
        Task<bool> Registrar(FacturaTipoDocumentoDTO model);
		Task<bool> Modificar(int id, FacturaTipoDocumentoDTO model);
	}
}
