using DepilZone.Entidad.DTO.Facturacion;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DepilZone.Data.Interface.Facturacion
{
	public interface IFacturaDatosClienteDat
	{
		Task<List<FacturaDatosClienteDTO>> ListarByCliente(int idUsuario, int IdCliente);
		Task<List<FacturaDatosClienteDTO>> ListarByCliente2(int idUsuario,int IdCliente);
        Task<FacturaDatosClienteDTO> Buscar(int Id, int IdUsuario);
        Task<FacturaDatosClienteDTO> BuscarPredeterminado(int IdCliente, int IdTipoComprobante, int IdUsuario);
        Task<bool> Registrar(FacturaDatosClienteDTO model);
		Task<bool> Modificar(int id, FacturaDatosClienteDTO model);

        Task<FacturaDatosClienteDTO> BuscarPorNumeroDocumento(string numeroDocumento, int idUsuario);

    }
}
