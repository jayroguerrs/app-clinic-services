using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
    public interface IEvolucionCitaMensualDat
    {
        Task<Respuesta<EvolucionCitaMensualEnt>> Insertar(DateTime fecha);
        Task<EvolucionCitaMensualDTO> Obtener(DateTime fecha, int idSede);
    }
}
