using DepilZone.Api.CustomFilter;
using DepilZone.Application.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class PromocionController : ControllerBase
    {
        private readonly IPromocionApp _IPromocionApp;
        public PromocionController(IPromocionApp IPromocionApp)
        {
            this._IPromocionApp = IPromocionApp;
        }

        [HttpGet("vista/{idPromocion}")]
        [CustomFilter("000077")]
        public async Task<IEnumerable<PromocionVistaDetalleDTO>> ObtenerPromocionVistaDetalle(int idPromocion)
        {
            try
            {
                return await _IPromocionApp.ObtenerPromocionVistaDetalle(idPromocion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        [HttpGet("plantilla/{idPromocion}")]
        [CustomFilter("000078")]
        public async Task<IEnumerable<PromocionVistaDatosPlantillaDTO>> ObtenerPromocionVistaPlantilla(int idPromocion)
        {
            return await _IPromocionApp.ObtenerPromocionVistaPlantilla(idPromocion);
        }
        [HttpGet("condicion/{idPromocion}")]
        [CustomFilter("000079")]
        public async Task<PromocionVistaDatosCondicionadoDTO> ObtenerPromocionVistaCondicionado(int idPromocion)
        {
            return await _IPromocionApp.ObtenerPromocionVistaCondicionado(idPromocion);
        }
        [HttpGet("activo/{activo}")]
        [CustomFilter("000080")]
        public async Task<IEnumerable<PromocionGrillaDTO>> Obtener(int activo)
        {
            try
            {
                return await _IPromocionApp.Obtener(activo);
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }
        [HttpGet("activo/{activo}/modulo")]
        [CustomFilter("000081")]
        public async Task<IEnumerable<PromocionGrillaDTO>> ObtenerParaModulo(int activo)
        {
            try
            {
                return await _IPromocionApp.ObtenerParaModulo(activo);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        [HttpGet("activo/{activo}/{idServicio}/modulo")]
        [CustomFilter("000082")]
        public async Task<IEnumerable<PromocionGrillaDTO>> ObtenerParaModuloByServicio(int activo, int idServicio)
        {
            try
            {
                return await _IPromocionApp.ObtenerParaModuloByServicio(activo, idServicio);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        [HttpGet("activo/{activo}/servicio/{idServicio}")]
        [CustomFilter("000083")]
        public async Task<IEnumerable<PromocionGrillaDTO>> ObtenerPorServicio(int activo, int idServicio)
        {
            return await _IPromocionApp.ObtenerPorServicio(activo, idServicio);
        }
        [HttpGet("categoria/{idCategoria}/{activo}")]
        [CustomFilter("000084")]
        public async Task<IEnumerable<PromocionGrillaDTO>> ObtenerPorCategoria(int idCategoria, int activo)
        {
            return await _IPromocionApp.ObtenerPorCategoria(idCategoria, activo);
        }
        [HttpGet("{id}")]
        [CustomFilter("000085")]
        public async Task<PromocionDTO> ObtenerById(int id)
        {
            return await _IPromocionApp.ObtenerById(id);
        }
        [HttpGet("search/{str}")]
        [CustomFilter("000086")]
        public async Task<IEnumerable<PromocionGrillaDTO>> LikeNombre(string str)
        {
            return await _IPromocionApp.ObtenerByLikeNombre(str);
        }
        [HttpPost]
        [CustomFilter("000087")]
        public async Task<Respuesta<PromocionEnt>> Post(PromocionEnt model)
        {
            return await _IPromocionApp.Insertar(model);
        }
        [HttpPut]
        [CustomFilter("000088")]
        public async Task<Respuesta<PromocionEnt>> Put(PromocionEnt model)
        {
            try
            {
                return await _IPromocionApp.Modificar(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        [HttpGet("ranking-venta/{fechaInicio}/{fechaFin}/{idSede}/{idPromocion}")]
        [CustomFilter("000089")]
        public async Task<ActionResult> ObtenerRankingVenta(DateTime fechaInicio, DateTime fechaFin, int idSede, int idPromocion)
        {
            try
            {
                var collection = await _IPromocionApp.ObtenerRankingVenta( fechaInicio,  fechaFin,  idSede, idPromocion);
                return Ok(new {
                    data = collection,
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = e.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }
        [HttpGet("ranking-agendados/{fechaInicio}/{fechaFin}/{idSede}/{idPromocion}")]
        [CustomFilter("000090")]
        public async Task<ActionResult> ObtenerRankingAgendados(DateTime fechaInicio, DateTime fechaFin, int idSede, int idPromocion)
        {
            try
            {
                var collection = await _IPromocionApp.ObtenerRanking(fechaInicio, fechaFin, idSede, idPromocion);
                return Ok(new
                {
                    data = collection,
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = e.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }
        [HttpGet("ranking-atendidos/{fechaInicio}/{fechaFin}/{idSede}/{idPromocion}")]
        [CustomFilter("000091")]
        public async Task<ActionResult> ObtenerRankingAtendidos(DateTime fechaInicio, DateTime fechaFin, int idSede, int idPromocion)
        {
            try
            {
                var collection = await _IPromocionApp.ObtenerRankingAtendido(fechaInicio, fechaFin, idSede, idPromocion);
                return Ok(new
                {
                    data = collection,
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = e.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }
        [HttpGet("top10Zonas/{fechaInicio}/{fechaFin}/{idSede}/{idTipo}/{idPromocion}")]
        [CustomFilter("000092")]
        public async Task<ActionResult> ObtenerTop10Zonas(DateTime fechaInicio, DateTime fechaFin, int idSede, int idTipo, int idPromocion)
        {
            try
            {
                var collection = await _IPromocionApp.ObtenerTop10Zonas(fechaInicio, fechaFin, idSede, idTipo, idPromocion);
                return Ok(new
                {
                    data = collection,
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = e.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }
        [HttpGet("bottom10Zonas/{fechaInicio}/{fechaFin}/{idSede}/{idTipo}/{idPromocion}")]
        [CustomFilter("000093")]
        public async Task<ActionResult> ObtenerBottom10Zonas(DateTime fechaInicio, DateTime fechaFin, int idSede, int idTipo, int idPromocion)
        {
            try
            {
                var collection = await _IPromocionApp.ObtenerBottom10Zonas(fechaInicio, fechaFin, idSede, idTipo, idPromocion);
                return Ok(new
                {
                    data = collection,
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = e.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }
        [HttpGet("zonasRanking/{fechaInicio}/{fechaFin}/{idSede}/{idTipo}/{idPromocion}")]
        [CustomFilter("000094")]
        public async Task<ActionResult> ObtenerZonasRanking(DateTime fechaInicio, DateTime fechaFin, int idSede, int idTipo, int idPromocion)
        {
            try
            {
                var collection = await _IPromocionApp.ObtenerZonasRanking(fechaInicio, fechaFin, idSede, idTipo, idPromocion);
                return Ok(new
                {
                    data = collection,
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = e.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }
        [HttpPost("clonar/{idPromocion}/{idUsuario}")]
        [CustomFilter("000095")]
        public async Task<ActionResult> Clonar(int idPromocion, int idUsuario)
        {
            try
            {
                var collection = await _IPromocionApp.Clonar(idPromocion, idUsuario);
                return Ok(new
                {
                    data = collection,
                    message = "",
                    status = StatusCodes.Status201Created
                });
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = e.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }

        [HttpPut("update-status")]
        public async Task<GeneralResponse<bool>> UpdateAllPromotionStatus([FromBody] PromocionStatusDTO[] promotions)
        {
            try
            {
                GeneralResponse<bool> response = await _IPromocionApp.UpdateAllPromotionStatus(promotions);
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
