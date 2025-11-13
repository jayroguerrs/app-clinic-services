using DepilZone.Application.Interface.C360;
using DepilZone.Domain.Interface.C360;
using DepilZone.Entidad.DTO.C360;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DepilZone.Application.Implement.C360
{
    public class Cita360App : ICita360App
    {
        private readonly ICita360Dom _ICita360Dom;
        public Cita360App(ICita360Dom ICita360Dom)
        {
            _ICita360Dom = ICita360Dom;
        }
        public async Task<bool> Insertar(Cita360DTO model)
        {
            return await _ICita360Dom.Insertar(model);
        }
        public async Task<bool> Modificar(int idCita, Cita360DTO model)
        {
            return await _ICita360Dom.Modificar(idCita, model);
        }
        public async Task<List<Cita360DTO>> BuscarByCronograma(int idCronograma)
        {
            return await _ICita360Dom.BuscarByCronograma(idCronograma);
        }
        public async Task<Cita360DTO> BuscarById(int idCita)
        {
            return await _ICita360Dom.BuscarById(idCita);
        }
        public async Task<bool> Cancelar(Cita360DTO model)
        {
            return await _ICita360Dom.Cancelar(model);
        }
        public async Task<bool> Pendiente(Cita360DTO model)
        {
            return await _ICita360Dom.Pendiente(model);
        }
        public async Task<bool> Anular(Cita360DTO model)
        {
            return await _ICita360Dom.Anular(model);
        }
        public async Task<bool> Confirmar(Cita360DTO model)
        {
            return await _ICita360Dom.Confirmar(model);
        }
        public async Task<bool> ConfirmarAsistencia(Cita360DTO model)
        {
            return await _ICita360Dom.ConfirmarAsistencia(model);
        }
        public async Task<bool> Atender(Cita360DTOAtender model)
        {
            return await _ICita360Dom.Atender(model);
        }
        public async Task<bool> NoLlamar(Cita360DTO model)
        {
            return await _ICita360Dom.NoLlamar(model);
        }
    }
}