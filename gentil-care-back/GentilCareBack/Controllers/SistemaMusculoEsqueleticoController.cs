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
    [Route("api/SistemaMusculoEsqueletico")]
    public class SistemaMusculoEsqueleticoController : ControllerBase
    {
        private readonly ISistemaMusculoEsqueleticoService _sistemaMusculoEsqueleticoService;
        public SistemaMusculoEsqueleticoController(ISistemaMusculoEsqueleticoService sistemaMusculoEsqueleticoService)
        {
            this._sistemaMusculoEsqueleticoService = sistemaMusculoEsqueleticoService;
        }

        [HttpGet("getData")]
        public async Task<ActionResult> getDatas()
        {
            return Ok(await _sistemaMusculoEsqueleticoService.GetAllAsync());
        }

        [HttpGet("getData/{id}")]
        public async Task<ActionResult> getDatas(long id)
        {
            return Ok(await _sistemaMusculoEsqueleticoService.GetByIdAsync(id));
        }

        [HttpPost("add")]
        public async Task<ActionResult> add(SistemaMusculoEsqueleticoDto sistemaMusculoEsqueleticoDto)
        {
            return Ok(await _sistemaMusculoEsqueleticoService.InsertAsync(sistemaMusculoEsqueleticoDto));
        }

        [HttpPut("edit")]
        public async Task<ActionResult> edit(SistemaMusculoEsqueleticoDto sistemaMusculoEsqueleticoDto)
        {
            return Ok(await _sistemaMusculoEsqueleticoService.UpdateAsync(sistemaMusculoEsqueleticoDto));
        }

        [HttpDelete("deleteData/{id}")]
        public async Task<ActionResult> deleteData(long id)
        {
            return Ok(await _sistemaMusculoEsqueleticoService.GetByIdAsync(id));
        }
    }
}
