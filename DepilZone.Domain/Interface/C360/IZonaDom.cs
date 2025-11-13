using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using DepilZone.Entidad.DTO.C360;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface.C360
{
	public interface IZonaDom
	{
        Task<List<ZonaDTO>> Listar();
        Task<List<ZonaDTO>> ListarByEstado(int idEstado);
        Task<bool> Registrar(ZonaDTO model);
        Task<bool> Modificar(int id, ZonaDTO model);
    }
}
