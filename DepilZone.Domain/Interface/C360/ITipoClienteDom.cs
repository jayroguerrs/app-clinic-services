using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using DepilZone.Entidad.DTO.C360;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface.C360
{
	public interface ITipoClienteDom
	{
        Task<List<TipoCliente360DTO>> Listar();
        Task<List<TipoCliente360DTO>> ListarByEstado(int idEstado);
        Task<bool> Registrar(TipoCliente360DTO model);
        Task<bool> Modificar(int id, TipoCliente360DTO model);
    }
}
