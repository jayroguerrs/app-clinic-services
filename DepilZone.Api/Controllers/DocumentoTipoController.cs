using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DepilZone.Api.CustomFilter;
using DepilZone.Application.Implement;
using DepilZone.Application.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using DepilZone.Entidad.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class DocumentoTipoController : ControllerBase
    {
        private readonly IDocumentoTipoApp _documentoTipo;
        public DocumentoTipoController(IDocumentoTipoApp DocumentoTipoApp)
        {
            _documentoTipo = DocumentoTipoApp;
        }

        [HttpGet]
        [CustomFilter("000365")]
        public async Task<IEnumerable<DocumentoTipoDTO>> ObtenerListado()
        {
            return await _documentoTipo.ObtenerListado();
        }
        [HttpPost]
        [CustomFilter("000366")]
        public async Task<ActionResult> Create(DocumentoTipoDTO model)
        {
            try
            {
                return Ok(new
                {
                    data = await _documentoTipo.Insertar(model),
                    message = "",
                    status = StatusCodes.Status201Created
                });
            }
            catch (AlertException ex)
            {
                return Ok(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }
        [HttpGet("{id}")]
        [CustomFilter("000367")]
        public async Task<ActionResult> Find(int id)
        {
            try
            {
                return Ok(new
                {
                    data = await _documentoTipo.ObtenerById(id),
                message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (AlertException ex)
            {
                return Ok(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }
        [HttpPut]
        [CustomFilter("000368")]
        public async Task<ActionResult> Update(DocumentoTipoDTO model)
        {
            try
            {
                return Ok(new
                {
                    data = await _documentoTipo.Modificar(model),
                message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (AlertException ex)
            {
                return Ok(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }
        [HttpGet("{id}/perfiles")]
        [CustomFilter("000369")]
        public async Task<IEnumerable<DocumentoTipoPerfilDTO>> FindProfiles(int id)
        {
            return await _documentoTipo.ObtenerPerfilesById(id);
        }
        [HttpPut("{id}/perfiles")]
        [CustomFilter("000370")]
        public async Task<Respuesta<DocumentoTipoEnt>> AssignProfiles( int id, int[] profiles )
        {
            return await _documentoTipo.AsignarPerfiles(id, profiles);
        }
        [HttpGet("servicio/{idServicio}")]
        [CustomFilter("000371")]
        public async Task<ActionResult> ListarByServicio(int idServicio)
        {
            try
            {
                return Ok(new
                {
                    data = await _documentoTipo.ListarByServicio(idServicio),
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status200OK
                });
            }
        }

        [HttpPut("update-status")]
        public async Task<GeneralResponse<bool>> UpdateAllDocumentStatus([FromBody] DocumentStatusDTO[] documents)
        {
            try
            {
                GeneralResponse<bool> response = await _documentoTipo.UpdateAllDocumentStatus(documents);
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}