
using DepilZone.Application.Interface.Facturacion;
using DepilZone.Data.Interface.Facturacion;
using DepilZone.Entidad.DTO.Facturacion;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement.Facturacion
{
	public class FacturaDatosClienteApp : IFacturaDatosClienteApp
	{
		private readonly IFacturaDatosClienteDom _IFacturaDatosClienteDom;
        public FacturaDatosClienteApp(IFacturaDatosClienteDom IFacturaDatosClienteDom)
        {
            this._IFacturaDatosClienteDom = IFacturaDatosClienteDom;
        }

        public async Task<List<FacturaDatosClienteDTO>> ListarByCliente(int IdUsuario, int IdCliente)
        {
            return await _IFacturaDatosClienteDom.ListarByCliente(IdUsuario, IdCliente);
        }

        public async Task<List<FacturaDatosClienteDTO>> ListarByCliente2(int IdUsuario, int IdCliente)
        {
            return await _IFacturaDatosClienteDom.ListarByCliente2(IdUsuario, IdCliente);
        }

        public async Task<FacturaDatosClienteDTO> Buscar(int Id, int IdUsuario)
        {
            return await _IFacturaDatosClienteDom.Buscar(Id, IdUsuario);
        }

        public async Task<FacturaDatosClienteDTO> BuscarPredeterminado(int IdCliente, int IdTipoComprobante, int IdUsuario)
        {
            return await _IFacturaDatosClienteDom.BuscarPredeterminado(IdCliente, IdTipoComprobante, IdUsuario);
        }

        public async Task<bool> Registrar(FacturaDatosClienteDTO model)
        {
            return await _IFacturaDatosClienteDom.Registrar(model);
        }
        public async Task<bool> Modificar(int id, FacturaDatosClienteDTO model)
        {
            return await _IFacturaDatosClienteDom.Modificar(id, model);
        }


        public async Task<FacturaDatosClienteDTO> BuscarPorNumeroDocumento(string numeroDocumento, int idUsuario)
        {
            return await _IFacturaDatosClienteDom.BuscarPorNumeroDocumento(numeroDocumento, idUsuario);
        }


       
    }
}
