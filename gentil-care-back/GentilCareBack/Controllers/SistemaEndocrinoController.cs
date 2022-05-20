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
    [Route("api/SistemaEndocrino")]
    public class SistemaEndocrinoController : ControllerBase
    {
        private readonly ISistemaEndocrinoService _sistemaEndocrinoService;
        public SistemaEndocrinoController(ISistemaEndocrinoService sistemaEndocrinoService)
        {
            this._sistemaEndocrinoService = sistemaEndocrinoService;
        }

        [HttpGet("getData")]
        public async Task<ActionResult> getDatas()
        {
            return Ok(await _sistemaEndocrinoService.GetAllAsync());
        }

        [HttpGet("getData/{id}")]
        public async Task<ActionResult> getDatas(long id)
        {
            return Ok(await _sistemaEndocrinoService.GetByIdAsync(id));
        }

        [HttpPost("add")]
        public async Task<ActionResult> add(SistemaEndocrinoDto sistemaEndocrinoDto)
        {
            return Ok(await _sistemaEndocrinoService.InsertAsync(sistemaEndocrinoDto));
        }

        [HttpPut("edit")]
        public async Task<ActionResult> edit(SistemaEndocrinoDto sistemaEndocrinoDto)
        {
            return Ok(await _sistemaEndocrinoService.UpdateAsync(sistemaEndocrinoDto));
        }

        [HttpDelete("deleteData/{id}")]
        public async Task<ActionResult> deleteData(long id)
        {
            return Ok(await _sistemaEndocrinoService.GetByIdAsync(id));
        }
    }
}
