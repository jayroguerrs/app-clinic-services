using DepilZone.Application.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad.DTO;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
	public class AtencionClienteApp : IAtencionClienteApp
	{
		private readonly IAtencionClienteDom _IAtencionClienteDom;
        public AtencionClienteApp(IAtencionClienteDom IAtencionClienteDom)
        {
            this._IAtencionClienteDom = IAtencionClienteDom;
        }

        public async Task<bool> Insertar(AtencionClienteRegistrarDTO model)
        {
            return await _IAtencionClienteDom.Insertar(model);
        }
       
    }
}
