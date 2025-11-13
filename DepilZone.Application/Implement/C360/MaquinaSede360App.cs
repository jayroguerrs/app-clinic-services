using DepilZone.Application.Interface.C360;
using DepilZone.Domain.Interface.C360;
using DepilZone.Entidad.DTO;
using DepilZone.Entidad.DTO.C360;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DepilZone.Application.Implement.C360
{
    public class MaquinaSede360App : IMaquinaSede360App
    {
        private readonly IMaquinaSede360Dom _IMaquinaSede360Dom;
        public MaquinaSede360App(IMaquinaSede360Dom IMaquinaSede360Dom)
        {
            _IMaquinaSede360Dom = IMaquinaSede360Dom;
        }
        public async Task<List<MaquinaSede360DisponibleDTO>> BuscarFechaDisponible(DateTime fechaDesde, DateTime fechaHasta, int idServicio, int idSede)
        {
            return await _IMaquinaSede360Dom.BuscarFechaDisponible(fechaDesde, fechaHasta, idServicio, idSede);
        }
        public async Task<List<MaquinaSede360DTO>> VerMaquinaDisponible(DateTime fecha, int idServicio, int idSede)
        {
            return await _IMaquinaSede360Dom.VerMaquinaDisponible(fecha, idServicio, idSede);
        }
        public async Task<MaquinaSede360DTO> VerMaquinaDisponibleById(int IdMaquina, DateTime fecha, int idServicio, int idSede)
        {
            return await _IMaquinaSede360Dom.VerMaquinaDisponibleById(IdMaquina, fecha, idServicio, idSede);
        }
        public async Task<bool> AsignarTecnologias(int idMaquinaSede, MaquinaSedeTecnologia360DTO model)
        {
            return await _IMaquinaSede360Dom.AsignarTecnologias(idMaquinaSede, model);
        }
        public async Task<List<TecnologiaDTO>> ListarTecnologias(int idMaquinaSede)
        {
            return await _IMaquinaSede360Dom.ListarTecnologias(idMaquinaSede);
        }

    }
    
}