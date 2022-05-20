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
    [Route("api/SistemaEmatopoyetico")]
    public class SistemaEmatopoyeticoController : ControllerBase
    {
        private readonly ISistemaEmatopoyeticoService _sistemaEmatopoyeticoService;
        public SistemaEmatopoyeticoController(ISistemaEmatopoyeticoService sistemaEmatopoyeticoService)
        {
            this._sistemaEmatopoyeticoService = sistemaEmatopoyeticoService;
        }

        [HttpGet("getData")]
        public async Task<ActionResult> getDatas()
        {
            return Ok(await _sistemaEmatopoyeticoService.GetAllAsync());
        }

        [HttpGet("getData/{id}")]
        public async Task<ActionResult> getDatas(long id)
        {
            return Ok(await _sistemaEmatopoyeticoService.GetByIdAsync(id));
        }

        [HttpPost("add")]
        public async Task<ActionResult> add(SistemaEmatopoyeticoDto sistemaDigestivoDto)
        {
            return Ok(await _sistemaEmatopoyeticoService.InsertAsync(sistemaDigestivoDto));
        }

        [HttpPut("edit")]
        public async Task<ActionResult> edit(SistemaEmatopoyeticoDto sistemaDigestivoDto)
        {
            return Ok(await _sistemaEmatopoyeticoService.UpdateAsync(sistemaDigestivoDto));
        }

        [HttpDelete("deleteData/{id}")]
        public async Task<ActionResult> deleteData(long id)
        {
            return Ok(await _sistemaEmatopoyeticoService.GetByIdAsync(id));
        }
    }
}
