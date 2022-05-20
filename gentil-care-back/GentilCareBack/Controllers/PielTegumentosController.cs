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
    [Route("api/PielTegumentos")]
    public class PielTegumentosController : ControllerBase
    {
        private readonly IPielTegumentosService _pielTegumentosService;
        public PielTegumentosController(IPielTegumentosService pielTegumentosService)
        {
            this._pielTegumentosService = pielTegumentosService;
        }

        [HttpGet("getData")]
        public async Task<ActionResult> getDatas()
        {
            return Ok(await _pielTegumentosService.GetAllAsync());
        }

        [HttpGet("getData/{id}")]
        public async Task<ActionResult> getDatas(long id)
        {
            return Ok(await _pielTegumentosService.GetByIdAsync(id));
        }

        [HttpPost("add")]
        public async Task<ActionResult> add(PielTegumentosDto pielTegumentosDto)
        {
            return Ok(await _pielTegumentosService.InsertAsync(pielTegumentosDto));
        }

        [HttpPut("edit")]
        public async Task<ActionResult> edit(PielTegumentosDto pielTegumentosDto)
        {
            return Ok(await _pielTegumentosService.UpdateAsync(pielTegumentosDto));
        }

        [HttpDelete("deleteData/{id}")]
        public async Task<ActionResult> deleteData(long id)
        {
            return Ok(await _pielTegumentosService.GetByIdAsync(id));
        }
    }
}
