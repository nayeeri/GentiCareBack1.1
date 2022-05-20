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
    [Route("api/AparatoRespiratorio")]
    public class AparatoRespiratorioController : ControllerBase
    {
        private readonly IAparatoRespiratorioService _aparatoRespiratorioService;
        public AparatoRespiratorioController(IAparatoRespiratorioService aparatoRespiratorioService)
        {
            this._aparatoRespiratorioService = aparatoRespiratorioService;
        }

        [HttpGet("getData")]
        public async Task<ActionResult> getDatas()
        {
            return Ok(await _aparatoRespiratorioService.GetAllAsync());
        }

        [HttpGet("getData/{id}")]
        public async Task<ActionResult> getDatas(long id)
        {
            return Ok(await _aparatoRespiratorioService.GetByIdAsync(id));
        }

        [HttpPost("addAparatoRespiratorio")]
        public async Task<ActionResult> add(AparatoRespiratorioDto aparatoRespiratorio)
        {
            return Ok(await _aparatoRespiratorioService.InsertAsync(aparatoRespiratorio));
        }

        [HttpPut("editAparatoRespiratorio")]
        public async Task<ActionResult> edit(AparatoRespiratorioDto aparatoRespiratorio)
        {
            return Ok(await _aparatoRespiratorioService.UpdateAsync(aparatoRespiratorio));
        }

        

        [HttpDelete("deleteData/{id}")]
        public async Task<ActionResult> deleteData(long id)
        {
            return Ok(await _aparatoRespiratorioService.GetByIdAsync(id));
        }
    }
}
