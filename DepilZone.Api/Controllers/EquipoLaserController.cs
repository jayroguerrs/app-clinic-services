using DepilZone.Api.CustomFilter;
using DepilZone.Application.Interface;
using DepilZone.Entidad;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class EquipoLaserController : ControllerBase
    {
        private readonly IEquipoLaserApp _IEquipoLaserApp;

        public EquipoLaserController(IEquipoLaserApp IEquipoLaserApp)
        {
            _IEquipoLaserApp = IEquipoLaserApp;
        }

        [HttpGet]
        //! TODO: REVIEW HEADERS
        [CustomFilter("000378")]
        public async Task<IEnumerable<EquipoLaserEnt>> Get()
        {
            try
            {
                return await _IEquipoLaserApp.Obtener();
            }
            catch ( Exception ex )
            {
                throw ex;
            }
        }

    }
}
