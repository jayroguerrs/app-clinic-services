using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
    public interface IPromocionCategoriaDat
    {
        Task<List<PromocionCategoriaDTO>> Listar();
        Task<bool> Registrar(PromocionCategoriaDTO model);
        Task<bool> Modificar(int id, PromocionCategoriaDTO model);
    }
}
