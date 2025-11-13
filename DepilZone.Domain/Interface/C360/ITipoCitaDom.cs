using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using DepilZone.Entidad.DTO.C360;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface.C360
{
	public interface ITipoCitaDom
	{
        Task<List<TipoCitaDTO>> Listar();
        Task<List<TipoCitaDTO>> ListarByEstado(int idEstado);
        Task<bool> Registrar(TipoCitaDTO model);
        Task<bool> Modificar(int id, TipoCitaDTO model);
    }
}
