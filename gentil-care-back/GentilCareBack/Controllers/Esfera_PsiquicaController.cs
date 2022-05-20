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
    [Route("api/Esfera_Psiquica")]
    public class Esfera_PsiquicaController : ControllerBase
    {
        private readonly IEsfera_PsiquicaService _esfera_PsiquicaService;
        public Esfera_PsiquicaController(IEsfera_PsiquicaService _esfera_PsiquicaService)
        {
            this._esfera_PsiquicaService = _esfera_PsiquicaService;
        }

        [HttpGet("getData")]
        public async Task<ActionResult> getDatas()
        {
            return Ok(await _esfera_PsiquicaService.GetAllAsync());
        }

        [HttpGet("getData/{id}")]
        public async Task<ActionResult> getDatas(long id)
        {
            return Ok(await _esfera_PsiquicaService.GetByIdAsync(id));
        }

        [HttpPost("add")]
        public async Task<ActionResult> add(Esfera_PsiquicaDto esfera_PsiquicaDto)
        {
            return Ok(await _esfera_PsiquicaService.InsertAsync(esfera_PsiquicaDto));
        }

        [HttpPut("edit")]
        public async Task<ActionResult> edit(Esfera_PsiquicaDto esfera_PsiquicaDto)
        {
            return Ok(await _esfera_PsiquicaService.UpdateAsync(esfera_PsiquicaDto));
        }

        [HttpDelete("deleteData/{id}")]
        public async Task<ActionResult> deleteData(long id)
        {
            return Ok(await _esfera_PsiquicaService.GetByIdAsync(id));
        }
    }
}
