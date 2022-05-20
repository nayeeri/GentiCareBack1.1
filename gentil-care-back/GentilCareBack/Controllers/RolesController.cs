using GentilCareBack.Dto;
using GentilCareBack.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GentilCareBack.Controllers
{
    [ApiController]
    [Route("api/admin")]
    public class RolesController : ControllerBase
    {
        private readonly IRolesService _rolesService;
        public RolesController(IRolesService rolesService)
        {
            this._rolesService = rolesService;
        }

        [HttpGet("listaRoles")]
        public async Task<ActionResult> getDatas()
        {
            return Ok(await _rolesService.GetAllAsync());
        }

        [HttpGet("getData/{id}")]
        public async Task<ActionResult> getDatas(long id)
        {
            return Ok(await _rolesService.GetByIdAsync(id));
        }

        [HttpPost("crearRol")]
        public async Task<ActionResult> add(requestRoles rolesDto)
        {
            var req = rolesDto.data;
            req.role = rolesDto.data.rol;

            return Ok(await _rolesService.InsertAsync(req));
        }

        [HttpPut("edit")]
        public async Task<ActionResult> edit(RolesDto rolesDto)
        {
            return Ok(await _rolesService.UpdateAsync(rolesDto));
        }

        [HttpDelete("eliminarRol/{id}")]
        public async Task<ActionResult> deleteData(long id)
        {
            return Ok(await _rolesService.DeleteAsync(id));
        }
    }
}
