
using DepilZone.Data.Interface.Facturacion;
using DepilZone.Entidad.DTO.Facturacion;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class FacturaDatosClienteDom: IFacturaDatosClienteDom
	{
		private readonly IFacturaDatosClienteDat _IFacturaDatosClienteDat;
		public FacturaDatosClienteDom(IFacturaDatosClienteDat IFacturaDatosClienteDat)
		{
			this._IFacturaDatosClienteDat = IFacturaDatosClienteDat;
		}
		public async Task<List<FacturaDatosClienteDTO>> ListarByCliente(int IdUsuario, int IdCliente)
		{
			return await _IFacturaDatosClienteDat.ListarByCliente(IdUsuario, IdCliente);
		}
        public async Task<List<FacturaDatosClienteDTO>> ListarByCliente2(int IdUsuario, int IdCliente)
        {
            return await _IFacturaDatosClienteDat.ListarByCliente2(IdUsuario, IdCliente);
        }
        public async Task<bool> Registrar(FacturaDatosClienteDTO model)
        {
            return await _IFacturaDatosClienteDat.Registrar(model);
        }
        public async Task<bool> Modificar(int id, FacturaDatosClienteDTO model)
        {
            return await _IFacturaDatosClienteDat.Modificar(id, model);
        }

        public async Task<FacturaDatosClienteDTO> Buscar(int Id, int IdUsuario)
        {
            return await _IFacturaDatosClienteDat.Buscar(Id, IdUsuario);
        }

        public async Task<FacturaDatosClienteDTO> BuscarPredeterminado(int IdCliente, int IdTipoComprobante, int IdUsuario)
        {
            return await _IFacturaDatosClienteDat.BuscarPredeterminado(IdCliente, IdTipoComprobante, IdUsuario);
        }


        public async Task<FacturaDatosClienteDTO> BuscarPorNumeroDocumento(string numeroDocumento, int idUsuario)
        {
            return await _IFacturaDatosClienteDat.BuscarPorNumeroDocumento(numeroDocumento, idUsuario);
        }

        


    }
}
