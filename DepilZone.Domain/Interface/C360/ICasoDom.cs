using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using DepilZone.Entidad.DTO.C360;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface.C360
{
	public interface ICasoDom
	{
        Task<List<CasoDTO>> Listar();
        Task<List<CasoDTO>> ListarByEstado(int idEstado);
        Task<bool> Registrar(CasoDTO model);
        Task<bool> Modificar(int id, CasoDTO model);
    }
}
