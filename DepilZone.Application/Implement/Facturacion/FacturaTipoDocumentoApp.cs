
using DepilZone.Application.Interface.Facturacion;
using DepilZone.Data.Interface.Facturacion;
using DepilZone.Entidad.DTO.Facturacion;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement.Facturacion
{
	public class FacturaTipoDocumentoApp : IFacturaTipoDocumentoApp
	{
		private readonly IFacturaTipoDocumentoDom _IFacturaTipoDocumentoDom;
        public FacturaTipoDocumentoApp(IFacturaTipoDocumentoDom IFacturaTipoDocumentoDom)
        {
            this._IFacturaTipoDocumentoDom = IFacturaTipoDocumentoDom;
        }

        public async Task<List<FacturaTipoDocumentoDTO>> Listar(int IdUsuario)
        {
            return await _IFacturaTipoDocumentoDom.Listar(IdUsuario);
        }

        public async Task<List<FacturaTipoDocumentoDTO>> Listar2(int IdUsuario)
        {
            return await _IFacturaTipoDocumentoDom.Listar2(IdUsuario);
        }

        public async Task<FacturaTipoDocumentoDTO> Buscar(int Id, int IdUsuario)
        {
            return await _IFacturaTipoDocumentoDom.Buscar(Id, IdUsuario);
        }

        public async Task<bool> Registrar(FacturaTipoDocumentoDTO model)
        {
            return await _IFacturaTipoDocumentoDom.Registrar(model);
        }
        public async Task<bool> Modificar(int id, FacturaTipoDocumentoDTO model)
        {
            return await _IFacturaTipoDocumentoDom.Modificar(id, model);
        }
        
    }
}
