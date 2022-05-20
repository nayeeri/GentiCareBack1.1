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
    [Route("api/SistemaDigestivo")]
    public class SistemaDigestivoController : ControllerBase
    {
        private readonly ISistemaDigestivoService _sistemaDigestivoService;
        public SistemaDigestivoController(ISistemaDigestivoService sistemaDigestivoService)
        {
            this._sistemaDigestivoService = sistemaDigestivoService;
        }

        [HttpGet("getData")]
        public async Task<ActionResult> getDatas()
        {
            return Ok(await _sistemaDigestivoService.GetAllAsync());
        }

        [HttpGet("getData/{id}")]
        public async Task<ActionResult> getDatas(long id)
        {
            return Ok(await _sistemaDigestivoService.GetByIdAsync(id));
        }

        [HttpPost("add")]
        public async Task<ActionResult> add(SistemaDigestivoDto sistemaDigestivoDto)
        {
            return Ok(await _sistemaDigestivoService.InsertAsync(sistemaDigestivoDto));
        }

        [HttpPut("edit")]
        public async Task<ActionResult> edit(SistemaDigestivoDto sistemaDigestivoDto)
        {
            return Ok(await _sistemaDigestivoService.UpdateAsync(sistemaDigestivoDto));
        }

        [HttpDelete("deleteData/{id}")]
        public async Task<ActionResult> deleteData(long id)
        {
            return Ok(await _sistemaDigestivoService.GetByIdAsync(id));
        }
    }
}
