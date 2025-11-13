using DepilZone.Data.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class HistoriaClinicaDom : IHistoriaClinicaDom
    {
        private readonly IHistoriaClinicaDat _IHistoriaClinicaDat;
        public HistoriaClinicaDom(IHistoriaClinicaDat IHistoriaClinicaDat)
        {
            this._IHistoriaClinicaDat = IHistoriaClinicaDat;
        }

        public async Task<HistoriaClinicaDTO> ObtenerDetallesCliente(int idCliente)
        {
            return await _IHistoriaClinicaDat.ObtenerDetallesCliente(idCliente);
        }

        public async Task<HistoriaClinicaDTO> Insertar(HistoriaClinicaDTO model)
        {
            return await _IHistoriaClinicaDat.Insertar(model);
        }

        public async Task<List<FichaAdmisionDTO>> ListarByCliente(int idCliente)
        {
            return await _IHistoriaClinicaDat.ListarByCliente(idCliente);
        }
        public async Task<List<FichaAdmisionDTO>> ListarByClientePorServicio(int idCliente, int idServicio)
        {
            return await _IHistoriaClinicaDat.ListarByClientePorServicio(idCliente, idServicio);
        }


        public async Task<bool> Anular(int idHistoria, int idUsuario)
        {
            return await _IHistoriaClinicaDat.Anular(idHistoria, idUsuario);
        }

        public async Task<HistoriaClinicaDTO> ObtenerDetallesById(int idFichaAdmision)
        {
            return await _IHistoriaClinicaDat.ObtenerDetallesById(idFichaAdmision);
        }
    }
}
