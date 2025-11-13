using DepilZone.Entidad.DTO;
using System.Threading.Tasks;


namespace DepilZone.Application.Interface
{
    public interface IAtencionClienteApp
	{
		Task<bool> Insertar(AtencionClienteRegistrarDTO model);
    }
}
