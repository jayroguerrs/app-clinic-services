
using DepilZone.Data.Interface.Facturacion;
using DepilZone.Entidad.DTO.Facturacion;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class FacturaTipoDocumentoDom: IFacturaTipoDocumentoDom
	{
		private readonly IFacturaTipoDocumentoDat _IFacturaTipoDocumentoDat;
		public FacturaTipoDocumentoDom(IFacturaTipoDocumentoDat IFacturaTipoDocumentoDat)
		{
			this._IFacturaTipoDocumentoDat = IFacturaTipoDocumentoDat;
		}
		public async Task<List<FacturaTipoDocumentoDTO>> Listar(int IdUsuario)
		{
			return await _IFacturaTipoDocumentoDat.Listar(IdUsuario);
		}
        public async Task<List<FacturaTipoDocumentoDTO>> Listar2(int IdUsuario)
        {
            return await _IFacturaTipoDocumentoDat.Listar2(IdUsuario);
        }
        public async Task<bool> Registrar(FacturaTipoDocumentoDTO model)
        {
            return await _IFacturaTipoDocumentoDat.Registrar(model);
        }
        public async Task<bool> Modificar(int id, FacturaTipoDocumentoDTO model)
        {
            return await _IFacturaTipoDocumentoDat.Modificar(id, model);
        }

        public async Task<FacturaTipoDocumentoDTO> Buscar(int Id, int IdUsuario)
        {
            return await _IFacturaTipoDocumentoDat.Buscar(Id, IdUsuario);
        }

    }
}
