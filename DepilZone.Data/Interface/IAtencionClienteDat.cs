using DepilZone.Data.Implement;
using DepilZone.Entidad.DTO;
using System.Threading.Tasks;


namespace DepilZone.Data.Interface
{
	public interface IAtencionClienteDat
	{
		Task<bool> Insertar(AtencionClienteRegistrarDTO model);
    }
}
