using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using DepilZone.Entidad.DTO.C360;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface.C360
{
	public interface ISalaDom
	{
        Task<List<SalaDTO>> Listar();
        Task<List<SalaDTO>> ListarByEstado(int idEstado);
        Task<bool> Registrar(SalaDTO model);
        Task<bool> Modificar(int id, SalaDTO model);
    }
}
