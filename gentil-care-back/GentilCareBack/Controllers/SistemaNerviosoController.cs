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
    [Route("api/SistemaNervioso")]
    public class SistemaNerviosoController : ControllerBase
    {
        private readonly ISistemaNerviosoService _sistemaNerviosoService;
        public SistemaNerviosoController(ISistemaNerviosoService sistemaNerviosoService)
        {
            this._sistemaNerviosoService = sistemaNerviosoService;
        }

        [HttpGet("getData")]
        public async Task<ActionResult> getDatas()
        {
            return Ok(await _sistemaNerviosoService.GetAllAsync());
        }

        [HttpGet("getData/{id}")]
        public async Task<ActionResult> getDatas(long id)
        {
            return Ok(await _sistemaNerviosoService.GetByIdAsync(id));
        }

        [HttpPost("add")]
        public async Task<ActionResult> add(SistemaNerviosoDto sistemaNerviosoDto)
        {
            return Ok(await _sistemaNerviosoService.InsertAsync(sistemaNerviosoDto));
        }

        [HttpPut("edit")]
        public async Task<ActionResult> edit(SistemaNerviosoDto sistemaNerviosoDto)
        {
            return Ok(await _sistemaNerviosoService.UpdateAsync(sistemaNerviosoDto));
        }

        [HttpDelete("deleteData/{id}")]
        public async Task<ActionResult> deleteData(long id)
        {
            return Ok(await _sistemaNerviosoService.GetByIdAsync(id));
        }
    }
}
