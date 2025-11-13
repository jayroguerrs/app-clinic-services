using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Interface
{
    public interface IEvolucionCitaMensualApp
    {
        Task<Respuesta<EvolucionCitaMensualEnt>> Insertar(DateTime fecha);
        Task<EvolucionCitaMensualDTO> Obtener(DateTime fecha, int idSede);
    }
}
