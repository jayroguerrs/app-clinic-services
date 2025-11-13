using DepilZone.Entidad.DTO;
using DepilZone.Entidad.DTO.C360;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface.C360
{
    public interface IMaquinaSede360Dat
    {
        Task<List<MaquinaSede360DisponibleDTO>> BuscarFechaDisponible(DateTime fechaDesde, DateTime fechaHasta, int idServicio, int idSede);
        Task<List<MaquinaSede360DTO>> VerMaquinaDisponible(DateTime fecha, int idServicio, int idSede);
        Task<MaquinaSede360DTO> VerMaquinaDisponibleById(int IdMaquina, DateTime fecha, int idServicio, int idSede);
        Task<bool> AsignarTecnologias(int idMaquinaSede, MaquinaSedeTecnologia360DTO model);
        Task<List<TecnologiaDTO>> ListarTecnologias(int idMaquinaSede);
    }
}
