using DepilZone.Application.Interface;
using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
	public class ClienteRecurrenteApp : IClienteRecurrenteApp
	{
        private readonly IClienteRecurrenteDom _IClienteRecurrenteDom;
        public ClienteRecurrenteApp(IClienteRecurrenteDom IClienteRecurrenteDom)
        {
            this._IClienteRecurrenteDom = IClienteRecurrenteDom;
        }

        public async Task<IEnumerable<ClienteRecurrenteDTO>> Obtener()
        {
            return await _IClienteRecurrenteDom.Obtener();
        }
        public async Task<IEnumerable<ClienteRecurrenteDTO>> Obtenercitafecha(DateTime fechaInicio, DateTime fechaTermino)
        {
            return await _IClienteRecurrenteDom.Obtenercitafecha(fechaInicio, fechaTermino);
        }
    }
}
