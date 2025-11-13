using DepilZone.Data.Implement;
using DepilZone.Data.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class FormularioDom : IFormularioDom
    {
        private readonly IFormularioDat _IFormularioDat;
        public FormularioDom(IFormularioDat IFormularioDat)
        {
            this._IFormularioDat = IFormularioDat;
        }

        public async Task<IEnumerable<PromocionFormDTO>> ObtenerPromocion(int id)
        {
            return await _IFormularioDat.ObtenerPromocion(id);
        }

        public async Task<IEnumerable<ServicioPromocionDTO>> ObtenerServiciosPorPromocion(int idPromocion, int idUsuario)
        {
            return await _IFormularioDat.ObtenerServiciosPorPromocion(idPromocion, idUsuario);
        }

        public async Task<IEnumerable<TipoClienteDTO>> ObtenerTipoCliente(int id)
        {
            return await _IFormularioDat.ObtenerTipoCliente(id);
        }

        public async Task<bool> RegistrarVenta(FormDTO formDTO)
        {
            return await _IFormularioDat.RegistrarVenta(formDTO);
        }
        public async Task<List<Dictionary<string, object>>> ReporteVenta(FilterFormDTO filterDTO)
        { 
            return await _IFormularioDat.ReporteVenta(filterDTO);
        }
    }
}
