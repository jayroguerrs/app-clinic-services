using DepilZone.Data.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad.DTO;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class AtencionClienteDom: IAtencionClienteDom
	{
		private readonly IAtencionClienteDat _IAtencionClienteDat;
		public AtencionClienteDom(IAtencionClienteDat IAtencionClienteDat)
		{
			this._IAtencionClienteDat = IAtencionClienteDat;
		}

        public async Task<bool> Insertar(AtencionClienteRegistrarDTO model)
        {
            return await _IAtencionClienteDat.Insertar(model);
        }
        
    }
}
