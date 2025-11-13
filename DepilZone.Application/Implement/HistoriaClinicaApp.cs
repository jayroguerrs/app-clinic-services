using DepilZone.Application.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class HistoriaClinicaApp : IHistoriaClinicaApp
    {
        private readonly IHistoriaClinicaDom _IHistoriaClinicaDom;
        public HistoriaClinicaApp(IHistoriaClinicaDom IHistoriaClinicaDom)
        {
            this._IHistoriaClinicaDom = IHistoriaClinicaDom;
        }
        public async Task<HistoriaClinicaDTO> ObtenerDetallesCliente(int idCliente)
        {
            return await _IHistoriaClinicaDom.ObtenerDetallesCliente(idCliente);
        }
        public async Task<HistoriaClinicaDTO> Insertar(HistoriaClinicaDTO model)
        {
            return await _IHistoriaClinicaDom.Insertar(model);
        }
        public async Task<List<FichaAdmisionDTO>> ListarByCliente(int idCliente)
        {
            return await _IHistoriaClinicaDom.ListarByCliente(idCliente);
        }

        public async Task<List<FichaAdmisionDTO>> ListarByClientePorServicio(int idCliente, int idServicio)
        {
            return await _IHistoriaClinicaDom.ListarByClientePorServicio(idCliente, idServicio);
        }

        public async Task<bool> Anular(int idHistoria, int idUsuario)
        {
            return await _IHistoriaClinicaDom.Anular(idHistoria, idUsuario);
        }

        public async Task<HistoriaClinicaDTO> ObtenerDetallesById(int idFichaAdmision)
        {
            return await _IHistoriaClinicaDom.ObtenerDetallesById(idFichaAdmision);
        }

    }
}
