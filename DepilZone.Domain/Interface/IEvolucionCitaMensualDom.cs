using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Domain.Interface
{
    public interface IEvolucionCitaMensualDom
    {
        Task<Respuesta<EvolucionCitaMensualEnt>> Insertar(DateTime fecha);
        Task<EvolucionCitaMensualDTO> Obtener(DateTime fecha, int idSede);
    }
}
